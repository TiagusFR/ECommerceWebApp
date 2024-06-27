using System.Collections.ObjectModel;

namespace ECommerceWebApp.Models
{
    public class Order
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid? OrderId { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public Guid? OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        
        //Navigation
        public ICollection<OrderDetail>? OrderDetails { get; set; } 
        public OrderStatus? OrderStatus { get; set; }
        public User? User { get; set; }
        
        
    }
}
