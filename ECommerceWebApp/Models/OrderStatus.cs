namespace ECommerceWebApp.Models
{
    public class OrderStatus
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid? StatusId { get; set; }
        public string? StatusName { get; set; }

        //Navigation
        public ICollection<Order>? Orders { get; set;}
    }
}
