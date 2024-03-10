using Microsoft.CodeAnalysis;

namespace ECommerceWebApp.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }

        //Navigation
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
