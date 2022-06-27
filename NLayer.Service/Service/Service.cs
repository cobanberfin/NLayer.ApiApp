using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//busıness codlelar
namespace NLayer.Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service( IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        } 
        public async Task<T> AddAsync(T entity) //ıdsını kullnamka ıstrsek dıye t don
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;

        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entites)
        {
            await _repository.AddRangeAsync(entites);
            await _unitOfWork.CommitAsync();
            return entites;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
             return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
             _repository.Remove(entity);
           await  _unitOfWork.CommitAsync();
        }

        public  async Task RemoveRangeAsync(IEnumerable<T> entites)
        {
            _repository.RemoveRange(entites);
            await _unitOfWork.CommitAsync();
        }

            public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> where(Expression<Func<T, bool>> expression)//IQuery donuyor asyn lık durum yok.tolist veya tolistasyncı bu metodu cagırdgımzda kullancak yanı apı tarfında
        {
           return _repository.where(expression);
        }
    }
}
