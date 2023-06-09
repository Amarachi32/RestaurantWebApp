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
        private IProductService _productService;
        private IOrderService _orderService;
        public IProductService productService
        {
            get
            {
                if(_productService == null)
                {
                    _productService= new ProductService();
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
                    _orderService= new OrderService();
                }
                return _orderService;
            }
        }
    }
}
