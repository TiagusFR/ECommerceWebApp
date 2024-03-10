using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWebApp.ModelsConfigurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder) 
        {
            builder.HasKey(cd => cd.Id);
            builder.Property(cd => cd.Id).ValueGeneratedOnAdd();

            //Relations
            builder.HasOne(cd => cd.Cart)
                .WithMany(p => p.CartDetails)
                .HasForeignKey(cd => cd.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cd => cd.Product)
                .WithMany()
                .HasForeignKey(cd => cd.ProductId);
        }

    }
}
