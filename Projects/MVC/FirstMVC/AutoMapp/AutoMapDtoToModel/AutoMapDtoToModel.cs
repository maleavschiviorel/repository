using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain.Domain;
using BLL.DTO;
using FirstMVC.Model;

namespace AutoMap.AutoMapDtoToModel
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderModel>();
            CreateMap< OrderModel,OrderDto >();
        }

    }
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientModel, ClientDto>();
            CreateMap<ClientDto, ClientModel>();
        }
    }
}