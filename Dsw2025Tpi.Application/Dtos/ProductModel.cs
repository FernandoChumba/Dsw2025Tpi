using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Application.Dtos;
public record ProductModel
{
  
    public record Request( //para crear y actualizar productos
        string Sku,
        string InternalCode,
        string Name,
        string Description,
        decimal Price,
        int Stock
        );

    public record Response(Guid id);//para devolver datos del producto
}

