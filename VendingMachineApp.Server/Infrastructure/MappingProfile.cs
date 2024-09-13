using AutoMapper;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.DTO;
using VendingMachineApp.Server.Models;

namespace VendingMachineApp.Server.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Drink, DrinkDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Coin, CoinDTO>();
        }
    }
}
