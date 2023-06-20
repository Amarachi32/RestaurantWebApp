using AutoMapper;
using Contracts.Interfaces;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private IRepositoryWrapper _repository;
        private IProductService _productService;
        private IOrderService _orderService;
        private IMapper _mapper;
        public ServiceManager(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository= repositoryWrapper;
            _mapper= mapper;
        }
        public IProductService productService
        {
            
            get 
            {
                if(_productService == null)
                {
                    _productService= new ProductService(_repository, _mapper);
                }
                return _productService;
            }
        }

        public IOrderService orderService
        {
            get
            {
                if(_orderService == null)
                {
                   // _orderService= new OrderService();
                }
                return _orderService;
            }
        }
        public void producting()
        {
            //_repository.
        }
    }
}
