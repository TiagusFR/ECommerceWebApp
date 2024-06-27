using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Controllers.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CartRequestDTO, Cart>();
            CreateMap<CartDetailRequestDTO, CartDetail>();
            CreateMap<OrderRequestDTO, Order>();
            CreateMap<OrderDetailRequestDTO, OrderDetail>();
            CreateMap<OrderStatusRequestDTO, OrderStatus>();
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<ProductCategoryRequestDTO, ProductCategory>();
            CreateMap<UserRequestDTO, User>();
        }
    }
}
