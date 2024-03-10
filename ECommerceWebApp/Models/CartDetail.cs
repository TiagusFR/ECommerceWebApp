using Microsoft.CodeAnalysis;

namespace ECommerceWebApp.Models
{
    public class CartDetail
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid? ShoppingCartId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }

        //Navigation
        public Cart? Cart { get; set; } 
        public Product? Product { get; set;}
    }
}
