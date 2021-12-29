using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(int id);
        void RemoveRangeAsync(IEnumerable<T> entities);

        //Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);



        //Task<IEnumerable<Developer>> GetAllDevelopersAsync();
    }
}
