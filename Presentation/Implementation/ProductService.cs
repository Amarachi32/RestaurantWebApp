
using Contracts.Interfaces;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ProductService: IProductService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper= repositoryWrapper;
        }
    }
}
