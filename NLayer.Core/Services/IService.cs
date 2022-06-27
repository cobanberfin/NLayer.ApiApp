using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> where(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); //varmı
        Task  <T>AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entites);
        //core katmanında update remove için Asyn metotları yoktu.ama Iservice de verıtabanına değişiklikleri yansıtacagımız ıcın async ye dönüştürdum.
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
 