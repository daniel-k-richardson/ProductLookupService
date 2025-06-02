using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductLookupService.Persistence.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasConversion(
                    v => v.Value,
                    v => new Name(v))
                .IsRequired();

            builder.Property(p => p.Description)
                .HasConversion(
                    v => v.Value,
                    v => new Description(v))
                .IsRequired();

            builder.OwnsOne(p => p.Size, sizeBuilder =>
            {
                sizeBuilder.Property(s => s.Value)
                    .HasColumnName("SizeValue")
                    .IsRequired();
                sizeBuilder.Property(s => s.Unit)
                    .HasColumnName("SizeUnit")
                    .HasConversion<int>()
                    .IsRequired();
            });

            builder.Property(p => p.Brand)
                .HasConversion(
                    v => v.Value,
                    v => new Brand(v))
                .IsRequired();

            builder.Property(p => p.Barcode)
                .HasConversion(
                    v => v.Value,
                    v => new Barcode(v))
                .IsRequired();

            builder.OwnsMany(p => p.NutritionFacts, nf =>
            {
                nf.WithOwner().HasForeignKey("ProductId");
                nf.Property(x => x.Name)
                    .HasConversion(
                        v => v.Value,
                        v => new NutritionName(v))
                    .HasColumnName("NutritionName")
                    .IsRequired();
                nf.Property(x => x.Value)
                    .HasConversion(
                        v => v.Value,
                        v => new NutritionValue(v))
                    .HasColumnName("NutritionValue")
                    .IsRequired();
                nf.HasKey("ProductId", "Name");
            });
        }
    }
}
