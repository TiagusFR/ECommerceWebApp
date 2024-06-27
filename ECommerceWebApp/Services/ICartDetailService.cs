using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface ICartDetailService
    {
        CartDetail? GetById(Guid id);
        List<CartDetail> GetAll();
        CartDetail Add(CartDetail cartDetail);
        void Update(Guid id, UpdateCartDetailRequestDTO request);
        void Delete(Guid id);
    }
}
