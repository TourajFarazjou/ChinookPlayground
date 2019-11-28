using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChinookPlayground.Domain.IRepositories
{
    /// <summary>
    /// https://code-maze.com/net-core-web-development-part4/
    /// https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //DbSet<TEntity> Entity { get;  }

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> expression = null,
            Func<IQueryable<TEntity>, Task<IOrderedEnumerable<TEntity>>> orderby = null,
            string property = "");

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entityToInsert);

        Task<TEntity> Update(TEntity entityToUpdate);

        Task Delete(TEntity entityToDelete);
    }
}
