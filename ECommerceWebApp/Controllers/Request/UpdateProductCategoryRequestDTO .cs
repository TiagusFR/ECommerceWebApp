namespace ECommerceWebApp.Controllers.Request
{
    public class UpdateProductCategoryRequestDTO
    {
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
