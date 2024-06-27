namespace ECommerceWebApp.Controllers.Request
{
    public class ProductRequestDTO
    {
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? Image { get; set; }
        public string? ProductColor { get; set; }
        public string? ProductSize { get; set; }
    }
}
