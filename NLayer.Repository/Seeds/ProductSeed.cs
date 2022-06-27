using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name="Dolma KaLem",
                Price = 100,
                Stock = 20,
                CreateDate= DateTime.Now 


            },
            
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Uçlu KaLem",
                Price = 100,
                Stock = 20,
                CreateDate = DateTime.Now
            }
            , 
            new Product
            {
                Id = 3,
                CategoryId = 1,
                Name = "Tükenmez KaLem",
                Price = 10,
                Stock = 205,
                CreateDate = DateTime.Now
            },
            new Product
            {
                Id = 4,
                CategoryId = 2,
                Name = "Masal",
                Price = 50,
                Stock = 210,
                CreateDate = DateTime.Now
            }, new Product
            {
                Id = 5,
                CategoryId = 2,
                Name = "Roman",
                Price = 100,
                Stock = 20,
                CreateDate = DateTime.Now
            }
            );
        }
    }
}
