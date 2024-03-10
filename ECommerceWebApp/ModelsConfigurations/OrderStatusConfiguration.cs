using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWebApp.EntityConfigurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);
            builder.Property(os => os.Id).ValueGeneratedOnAdd();

            // Relations
            builder.HasMany(os => os.Orders)
                   .WithOne(o => o.OrderStatus)
                   .HasForeignKey(o => o.OrderStatusId);
        }
    }
}
