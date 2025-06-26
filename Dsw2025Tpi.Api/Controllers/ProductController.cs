
using Dsw2025Tpi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Tpi.Api.Controllers;

//controlador de API y maneja solicitudes HTTP
[ApiController]
//Establece la ruta base para todas las acciones en este controlador
[Route("api/products")]

public class ProductController : ControllerBase // Hereda de ControllerBase (base para APIs)
{
    // inyecta el servicio de gestión de productos
    private readonly ProductsManagementServices _services;

    // Constructor que recibe el servicio por inyección de dependencias
    public ProductController(ProductsManagementServices services)
    {
        _services = services;
    }

    // Endpoint GET para obtener todos los productos
    [HttpGet()]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _services.GetProducts(); // Llama al servicio para obtener todos los productos 
        if (products == null || !products.Any()) return NoContent(); // Si no hay productos, retorna código 204
        return Ok(products);// Retorna código 200 (OK) con la lista de productos

    }

}
