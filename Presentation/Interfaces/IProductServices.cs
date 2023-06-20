using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IProductServices
    {
        Task<ApiResponse> Add(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<ApiResponse> DeleteProduct(Product product);
        Task<int> GetTotalProducts();
        Task<ApiResponse> UpdateProduct(Product product);
        Task<ApiResponse> UpdatePackagingList(List<PackagingList> lists, int productId);
    }
}
