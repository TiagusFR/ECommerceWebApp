namespace ECommerceWebApp.Models
{
    public class User
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? DocumentId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; } = false;


        //Navigation
        public ICollection<Order>? Orders { get; set; }
    }
}
