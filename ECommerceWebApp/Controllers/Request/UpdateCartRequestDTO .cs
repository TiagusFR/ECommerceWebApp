namespace ECommerceWebApp.Controllers.Request
{
    public class UpdateCartRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid? CartId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
