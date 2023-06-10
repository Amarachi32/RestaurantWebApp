using Contracts.Interfaces;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.Implementation
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();

        public Product GetProduct(int productId, bool trackChanges) =>
        FindByCondition(p => p.ProductId.Equals(productId), trackChanges).SingleOrDefault();

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(Product product)
        {

        }
        /*        public Product CreateProduct(Product product)
                {
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();

                    return product;
                }

                public void UpdateProduct(Product product)
                {
                    dbContext.Entry(product).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }

                public void DeleteProduct(int productId)
                {
                    var product = dbContext.Products.Find(productId);
                    dbContext.Products.Remove(product);
                    dbContext.SaveChanges();
                }

                public Product GetProductById(int productId)
                {
                    return dbContext.Products.Find(productId);
                }
        */
    }
}
