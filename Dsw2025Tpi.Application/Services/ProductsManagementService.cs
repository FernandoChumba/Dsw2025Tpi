

using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;

namespace Dsw2025Tpi.Application.Services;

public class ProductsManagementServices
{
    private readonly IRepository _repository;

    public ProductsManagementServices(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<Product?> GetProductById(Guid id)
    {
        return await _repository.GetById<Product>(id);
    }

    public async Task<List<Product>?> GetProducts()
    {
        return await _repository.GetAll<Product>();
    }


}

