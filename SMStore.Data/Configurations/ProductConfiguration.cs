using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMStore.Entities;

namespace SMStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.ProductCode).HasMaxLength(30);
            // Burada classlar arasındaki ilişkileri de belirtiyoruz
            builder.HasOne(b => b.Brand).WithMany(p => p.Products).HasForeignKey(b=>b.BrandId); // Burada Brand classı ile product classı arasında bir ilişki olacağını belirttik 1 olan kısım brand olduğu için hasone öelliğine brandi belirttik cok olan kısım product olacağı için bunu da withmany içerisinde belirttik. hasforeignkey de ise veritabanında oluşacak klonlardanBrandId nin foreign key olacağını belirttik

            builder.HasOne(b => b.Category).WithMany(p => p.Products).HasForeignKey(b => b.CategoryId);
        }
    }
}
