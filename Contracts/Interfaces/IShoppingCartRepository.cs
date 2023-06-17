using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetCart(int userId);
        Task<ApiResponse> UpdateShoppingCart(int userId, ShoppingItem shoppingItem);
        Task<ApiResponse> AddShoppingCart(int userId);
        Task<ShoppingCart> GetShoppingCartByID(int shoppingCartId, int userId);
        Task<ShoppingCart> GetCartWithShoppingItems(int userId);
        Task<ApiResponse> deleteShoppingItem(int shoppingItemId);
        Task<ShoppingCart> GetCartInIdWithShoppingItems(int shoppingCartId);
        Task<ApiResponse> UpdateShoppingCartPaymentMethod(int userId, string selectedPayment);
    }
}
