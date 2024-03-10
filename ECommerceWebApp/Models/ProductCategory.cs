namespace ECommerceWebApp.Models
{
    public class ProductCategory
    {
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        //Navigation 
        public ICollection<Product>? Products { get; set; }
        
    }
}
