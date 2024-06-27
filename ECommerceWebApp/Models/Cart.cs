namespace ECommerceWebApp.Models
{
    public class Cart
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid? CartId { get; set; }
        public bool IsDeleted { get; set; } = false;


        //Navigation
        public ICollection<CartDetail>? CartDetails { get; set; }
        
    }
}