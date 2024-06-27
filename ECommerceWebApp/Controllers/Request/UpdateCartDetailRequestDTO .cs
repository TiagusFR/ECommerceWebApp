namespace ECommerceWebApp.Controllers.Request
{
    public class UpdateCartDetailRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid? ShoppingCartId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
