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
            _context.Set<T>().Add(entity);
           /* if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (FindByCondition(x => x.Id == entity.Id, false).Any())
            {
                throw new ArgumentException("Entity already exists.", "entity");
            }
            _context.Set<T>().Add(entity);
            _context.SaveChanges();*/
        }

        public void Delete(T entity)
        {
           /* // Validate the entity.
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // Find the entity in the database.
            T existingEntity = _context.Set<T>().Find(entity.Id);*/

            // Delete the entity from the database.
            _context.Set<T>().Remove(entity);
          //  _context.SaveChanges();
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
         !trackChanges ? _context.Set<T>().AsNoTracking() :_context.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ? _context.Set<T>()
        .Where(expression)
        .AsNoTracking() :_context.Set<T>()
        .Where(expression);


        public void Update(T entity)
        {
            /* // Validate the entity.
             if (entity == null)
             {
                 throw new ArgumentNullException("entity");
             }

             // Find the entity in the database.
             T existingEntity = _context.Set<T>().Find(entity.Id);

             // Update the entity properties.
             foreach (var property in entity.GetType().GetProperties())
             {
                 if (property.CanWrite)
                 {
                     property.SetValue(existingEntity, property.GetValue(entity));
                 }
             }*/

            // Save the changes to the database.
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

          /*  using(TContext context = new TContext)
            {
                var updatedState = _context.Entry(entity);
                updatedState.State= EntityState.Modified;
                _context.SaveChanges();
            }*/
        }
    }
}
