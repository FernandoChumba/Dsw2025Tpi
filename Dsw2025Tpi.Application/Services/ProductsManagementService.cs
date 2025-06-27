

using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;

namespace Dsw2025Tpi.Application.Services;

public class ProductsManagementServices
{
    private readonly IRepository _repository; //instancia del repositorio (inyección de dependencias)

    // Constructor que recibe la dependencia IRepository
    public ProductsManagementServices(IRepository repository)

    {
        _repository = repository;
    }
    //obtener un producto específico por su ID
    public async Task<Product?> GetProductById(Guid id)
    {
        return await _repository.GetById<Product>(id);
    }

    //obtener todos los productos disponibles
    public async Task<List<Product>?> GetProducts()
    {
        return await _repository.GetAll<Product>();
    }

    public async Task<ProductModel.Response> AddProduct(ProductModel.Request request)
    {
        //Validación de datos de entrada
        if (string.IsNullOrWhiteSpace(request.Sku) ||
            string.IsNullOrWhiteSpace(request.Name) ||
            request.Price < 0 ||
            request.Stock < 0)
        {
            throw new ArgumentException("Valores para el producto no válidos");
        }
        //Verificación de unicidad del SKU
        var exist = await _repository.First<Product>(p => p.Sku == request.Sku);
        if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");

        //Creación de la entidad Product
        var product = new Product(request.Sku, request.InternalCode, request.Name, request.Description, request.Price, request.Stock);
        await _repository.Add(product);
        return new ProductModel.Response(product.Id);


    }
}