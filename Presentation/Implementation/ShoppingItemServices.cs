using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ShoppingItemServices
    {
        public IRepository<ShoppingItem> _shopItem;
        public IRepository<ShoppingCart> _shoppingCart;
        public IRepository<Product> _product;
        public IUnitOfWork _unitOfWork;

        public ShoppingItemServices(IRepository<ShoppingItem> shopItem, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _shopItem = unitOfWork.GetRepository<ShoppingItem>();
        }
        public async Task<ApiResponse> AddShoppingItemToCart(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = await _shoppingCart.Queryable
                    .Include(sc => sc.ShoppingItems)
                    .FirstOrDefaultAsync(sc => sc.CartId == cartId);

                if (cart == null)
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "Shopping cart not found"
                    };
                }

                var product = await _product.Queryable.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product == null)
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "Product not found"
                    };
                }

                if (product.Quantity < quantity)
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "Insufficient stock"
                    };
                }

                var shoppingItem = new ShoppingItem()
                {
                    Product = product,
                    Quantity = quantity
                };

                cart.ShoppingItems.Add(shoppingItem);

              //  await _shoppingCart.SaveChangesAsync();

                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Shopping item added to cart successfully"
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
