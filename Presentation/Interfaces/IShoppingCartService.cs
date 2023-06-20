

using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetCart(string userId);
        Task<ApiResponse> UpdateShoppingCart(string userId, ShoppingItem shoppingItem);
        Task<ApiResponse> AddShoppingCart(string userId);
        Task<ShoppingCart> GetShoppingCartByID(int shoppingCartId, string userId);
        Task<ShoppingCart> GetCartWithShoppingItems(string userId);
        Task<ApiResponse> deleteShoppingItem(int shoppingItemId);
        Task<ShoppingCart> GetCartInIdWithShoppingItems(int shoppingCartId);
        Task<ApiResponse> UpdateShoppingCartPaymentMethod(string userId, string selectedPayment);
    }
}
