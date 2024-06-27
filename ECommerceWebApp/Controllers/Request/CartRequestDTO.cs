namespace ECommerceWebApp.Controllers.Request
{
    public class CartRequestDTO
    {
        public Guid? Id {  get; set; }
        public Guid? CartId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
