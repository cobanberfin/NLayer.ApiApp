using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //bunları implement ettıgım zaman dbcontexin savechange ve savechangeasync metotlarını cagırmıs olucam
        Task CommitAsync();
        void Commit();
    }
}
