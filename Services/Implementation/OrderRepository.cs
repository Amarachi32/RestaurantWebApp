using Contracts.Interfaces;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{

    public class OrderRepository //: IOrderRepository
    {
        private readonly DbContext _dbContext;

        public OrderRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Order order)
        {
           // _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
