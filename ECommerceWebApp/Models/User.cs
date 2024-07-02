using Microsoft.AspNetCore.Identity;

namespace ECommerceWebApp.Models
{
    public class User : IdentityUser
    {
        public new Guid? Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public new string? Email { get; set; }
        public Guid? DocumentId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? Role {  get; set; }


        //Navigation
        public ICollection<Order>? Orders { get; set; }
    }
}
