using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);

        GetProductDto GetProduct(int productId, bool trackChanges);
        IEnumerable<GetProductDto> GetProducts(bool trackChanges);
        CreateProductDto CreateProduct(CreateProductDto product);
        void UpdateProduct(int ProductId, UpdateProductDto product, bool trackChanges);
        void DeleteProduct(int productId, bool trackChanges);
    }
}
