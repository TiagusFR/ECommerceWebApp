namespace ECommerceWebApp.Controllers.Request
{
    public class UpdateOrderStatusRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid? StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
