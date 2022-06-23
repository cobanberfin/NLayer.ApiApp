using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data.UnitOfWorks
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly AppDbContext _contex;
        public UnitofWork(AppDbContext contex)
        {
            _contex = contex;
        }

        public void Commit()
        {
            _contex.SaveChanges();
        }

        public  async Task CommitAsync()
        {
             await _contex.SaveChangesAsync();
        }
    }
}
