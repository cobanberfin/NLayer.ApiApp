using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> where (Expression <Func<T, bool>> expression); 
        IQueryable<T> GetAll (); 
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); //varmı
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T>entites);   //list degıl interface alıyorum
        void Update(T entity); 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entites);
         

    }
}
