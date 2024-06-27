using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        private readonly ApplicationDbContext _context = context;

        public Product? GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return [.. _context.Products];
        }

        public Product Add(Product products)
        {
            _context.Products.Add(products);
            return products;
        }

        public void Update(Guid id, UpdateProductRequestDTO request)
        {
            Product? productFound = GetById(id) ?? throw new ArgumentException($"Cannot find product with following Id:'{id}'");
            productFound.ProductId = request.ProductId;
            productFound.ProductName = request.ProductName;
            productFound.ProductPrice = request.ProductPrice;
            productFound.ProductDescription = request.ProductDescription;
            productFound.Image = request.Image;
            productFound.ProductColor = request.ProductColor;
            productFound.ProductSize = request.ProductSize;
        }

        public void Delete(Guid id)
        {
            Product? product = GetById(id) ?? throw new ArgumentException($"Cannot find product with following Id: '{id}'");
            _context.Products.Remove(product);
        }
    }
}
