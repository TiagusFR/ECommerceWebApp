namespace ECommerceWebApp.Controllers.Request
{
    public class OrderRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? OrderStatusId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
