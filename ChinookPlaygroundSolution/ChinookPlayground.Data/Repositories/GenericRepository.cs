using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ChinookPlayground.Data.DataContext;
using ChinookPlayground.Domain.IRepositories;

namespace ChinookPlayground.Data.Repositories
{
    /// <summary>
    /// https://code-maze.com/net-core-web-development-part4/
    /// https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/
    /// </summary>
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ChinookDbContext _context;

        public DbSet<TEntity> Entity => _context.Set<TEntity>();

        public GenericRepository(ChinookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync(); // AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> expression = null,
             Func<IQueryable<TEntity>, Task<IOrderedEnumerable<TEntity>>> orderby = null,
             string property = "")
        {
            IQueryable<TEntity> query = Entity;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderby != null)
            {
                return await orderby(query);
            }

            return await query.ToListAsync(); // AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entityToInsert)
        {
            Entity.Add(entityToInsert);

            await _context.SaveChangesAsync();

            return entityToInsert;
        }

        public async Task<TEntity> Update(TEntity entityToUpdate)
        {

            //Entity.Attach(entityToUpdate);

            //_context.Entry(entityToUpdate).State = EntityState.Modified;

            var result = Entity.Update(entityToUpdate);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task Delete(TEntity entityToDelete)
        {
            Entity.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
