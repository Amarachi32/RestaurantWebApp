using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IOrderRepository
    {
        Task<ApiResponse> AddOrder(ShoppingCart cart, double gst, double priceExclGst, double discount);
        Task<Order> Get(int id);
        Task<ApiResponse> DeleteOrder(int id);
        Task<ApiResponse> UpdateOrder(Order order);
        Task<Order> GetOrdersWithShoppingItems(int orderId);
        Task<List<Order>> GetOrdersByUserID(int userId, string dateFrom, string dateTo);
        Task<List<Order>> GetOrdersByDate(string dateFrom, string dateTo);
    }
}
