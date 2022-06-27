using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService :IService<Category>
    {
        //dto oluştur.category dto var ama product donmuoyr o yuzden önce  yenı dto yadım

        Task<CategoryWithProductsDto> GetSingleCategoryByIdWithProductAsync(int categoryId);
        


    }
}
