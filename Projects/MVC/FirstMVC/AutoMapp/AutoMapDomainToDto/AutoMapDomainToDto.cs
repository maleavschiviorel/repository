using AutoMapper;
using BLL.DTO;
using Domain.Domain;

namespace AutoMap.AutoMapDomainToDto
{
    public class OrderProfile : Profile
        {
            public OrderProfile()
            {
                CreateMap<Order, OrderDto>().ForMember(dst => dst.ClientId, opt => opt.MapFrom(src => src.Client.Id));
                CreateMap<OrderDto, Order>()
                    .AfterMap((src, dst) =>
                    {
                        if (src.Client != null)
                            dst.Client = Mapper.Map<Client>(src.Client);
                        else
                            dst.Client = new Client() { Id = src.ClientId };
                    });
            }

        }
        public class ClientProfile : Profile
        {
            public ClientProfile()
            {
                CreateMap<Client, ClientDto>();
                CreateMap<ClientDto, Client>();
            }
        }
  
}
