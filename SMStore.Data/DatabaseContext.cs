using Microsoft.EntityFrameworkCore;
using SMStore.Data.Configurations;
using SMStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMStore.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=SMStore;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentAPI : Veritabanı tablo ve klonlarını oluşturmak için data annotations a alternatif olarak kullanılabilen bir teknoloji
            modelBuilder.Entity<AppUser>().Property(a=>a.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Phone).HasColumnType("varchar(15)");
            modelBuilder.Entity<AppUser>().Property(a => a.Username).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(a => a.Password).IsRequired().HasColumnType("nvarchar(50)");
            // FluentAPI ile veritabanı oluştuktan sonra ilk kaydı ekleme
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id=1,
                    Email="admin@smstore.com",
                    IsActive=true,
                    IsAdmin=true,
                    Name="Admin",
                    Surname="User",
                    Username="Admin",
                    Password="123"

                });

            // Configurations altındaki classları burada tanımlamamız gerekiyor.
           // modelBuilder.ApplyConfiguration(new BrandConfiguration()); // Configuration classlarını bu şekilde tek tek çağırabiliriz.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Configuration classlarını bu şekilde topluca çağırabiliriz
            base.OnModelCreating(modelBuilder);
        }



    }
}
