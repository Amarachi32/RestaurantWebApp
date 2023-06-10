using Contracts.Interfaces;
using Domain.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        private ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext dbContext)
        { 
            _context= dbContext;
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
         !trackChanges ? _context.Set<T>().AsNoTracking() :_context.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ? _context.Set<T>()
        .Where(expression)
        .AsNoTracking() :_context.Set<T>()
        .Where(expression);

        /* public IQueryable<T> FindAll(bool trackChanges)
         {
             throw new NotImplementedException();
         }

         public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
         {
             throw new NotImplementedException();
         }*/

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
