using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IProductCategoryService
    {
        ProductCategory? GetById(Guid id);
        List<ProductCategory> GetAll();
        ProductCategory Add(ProductCategory productCategory);
        void Update(Guid id, UpdateProductCategoryRequestDTO request);
        void Delete(Guid id);
    }
}
