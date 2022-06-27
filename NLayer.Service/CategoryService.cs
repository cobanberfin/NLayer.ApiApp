using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryWithProductsDto> GetSingleCategoryByIdWithProductAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);
            var categoryDto= _mapper.Map<CategoryWithProductsDto>(category);
            return categoryDto;
        }
    }
}
