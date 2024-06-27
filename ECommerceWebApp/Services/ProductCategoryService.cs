using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ProductCategoryService (ApplicationDbContext context) : IProductCategoryService
    {
        private readonly ApplicationDbContext _context = context;

        public ProductCategory? GetById(Guid id)
        {
            return _context.ProductCategories.FirstOrDefault(p => p.CategoryId == id);
        }

        public List<ProductCategory> GetAll()
        {
            return [.. _context.ProductCategories];
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            return productCategory;
        }

        public void Update(Guid id, UpdateProductCategoryRequestDTO request)
        {
            ProductCategory? productCategoryFound = GetById(id) ?? throw new ArgumentException($"Cannot find product category with following Id:'{id}'");
            productCategoryFound.CategoryId = request.CategoryId;
            productCategoryFound.CategoryName = request.CategoryName;
        }

        public void Delete(Guid id)
        {
            ProductCategory? productCategory = GetById(id) ?? throw new ArgumentException($"Cannot find product category with following Id: '{id}'");
            _context.ProductCategories.Remove(productCategory);
        }
    }
}
