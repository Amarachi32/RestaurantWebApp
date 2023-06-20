using Contracts.Interfaces;
using Domain.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _context= applicationDbContext;
        }

        public IProductRepository productRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public IOrderRepository orderRepository
        {
            get
            {
                if(_orderRepository== null)
                {
                   // _orderRepository = new OrderRepository(_context);
                }
                return (_orderRepository);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
