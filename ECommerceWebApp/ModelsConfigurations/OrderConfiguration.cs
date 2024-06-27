using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace ECommerceWebApp.ModelsConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            //Relations
            builder.HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(o => o.OrderStatus)
                   .WithMany()
                   .HasForeignKey(o => o.OrderStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
