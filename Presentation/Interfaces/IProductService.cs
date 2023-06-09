using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
    }
}
