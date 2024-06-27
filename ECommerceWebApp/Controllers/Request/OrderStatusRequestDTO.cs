namespace ECommerceWebApp.Controllers.Request
{
    public class OrderStatusRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid? StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
