using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);

    }
}
