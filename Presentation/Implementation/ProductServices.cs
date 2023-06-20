using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ProductServices: IProductServices
    {
        private readonly IRepository<Product> _productDataRepository;
        private readonly IRepository<PackagingList> _packagingListDataRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productDataRepository = unitOfWork.GetRepository<Product>();
            _packagingListDataRepository = unitOfWork.GetRepository<PackagingList>();
        }
        public async Task<ApiResponse> Add(Product product)
        {
            try
            {
                _productDataRepository.Add(product);
               // await _productDataRepository.SaveChangesAsync();
                return new ApiResponse
                {
                    Status = "success",
                    Message = "Successfully add product"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productDataRepository.Queryable
                .Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            allProducts = await _productDataRepository.Queryable.ToListAsync();

            foreach (var item in allProducts)
            {
                List<PackagingList> packagingLists = await _packagingListDataRepository.Queryable.Where(pl => pl.ProductId == item.ProductId).ToListAsync();
                if (packagingLists.Count > 0)
                {
                    item.PackagingLists = packagingLists;
                }
            }

            return allProducts;
        }

        public async Task<ApiResponse> DeleteProduct(Product product)
        {
            try
            {
                _productDataRepository.Delete(product);
               // await _productDataRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully delete product"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }

        }

        public async Task<int> GetTotalProducts()
        {
            var result = await _productDataRepository.Queryable.CountAsync();
            return result;
        }

        public async Task<ApiResponse> UpdateProduct(Product product)
        {
            try
            {
                _productDataRepository.Update(product);
               // await _productDataRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully update product"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> UpdatePackagingList(List<PackagingList> lists, int productId)
        {
            try
            {
                List<PackagingList> originalList = await _packagingListDataRepository.Queryable.Where(pl => pl.ProductId == productId).ToListAsync();
                _packagingListDataRepository.DeleteRange(originalList);
              //  await _packagingListDataRepository.SaveChangesAsync();
                _packagingListDataRepository.AddRange(lists);
              //  await _packagingListDataRepository.SaveChangesAsync();

                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully update packaging"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }
    }
}

