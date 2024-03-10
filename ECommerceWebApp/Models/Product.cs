namespace ECommerceWebApp.Models
{
    public class Product
    {
        public Guid? ProductId { get; set; } = Guid.NewGuid();
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? Image { get; set; }
        public string? ProductColor { get; set; }
        public string? ProductSize { get; set; }

        //Navigation
        public ICollection<OrderDetail>? OrderDetails { get; set;}
        public ICollection<ProductCategory>? ProductCategories { get; set;}

    }
}
