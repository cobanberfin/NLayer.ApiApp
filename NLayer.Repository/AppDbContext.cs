using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entites;
using NLayer.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//options ile
namespace NLayer.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {


        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<ProductFeature>ProductFeatures { get; set; }

        //entıty ıle ılgılı ayarları yapabılmek ıcın :model oluşrken calıscak metot
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //   modelBuilder.ApplyConfiguration(new ProductConfiguration()) tektek yapar

            //bu  assemblyden tum confıgurtıon dosyalarını oku(reflexing yaparak IENtitytypeconfıguratıona )sahıp tum calssları bulup okur.



            //seedddata busekılde de yapıalbılır

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Mavi",
                Height = 100,
                Width = 200,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Yeşil",
                Height = 100,
                Width = 300,
                ProductId = 2


            }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
