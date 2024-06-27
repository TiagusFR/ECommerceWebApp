using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IProductService
    {
        Product? GetById(Guid id);
        List<Product> GetAll();
        Product Add(Product product);
        void Update(Guid id, UpdateProductRequestDTO request);
        void Delete(Guid id);
    }
}
