using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain.Domain;
using BLL.DTO;
using FirstMVC.Model;

namespace FirstMVC.AutoMapDtoToModel
{
    public class ModelOrderProfile : Profile
    {
        public ModelOrderProfile()
        {
            CreateMap<OrderDto, OrderModel>();
            CreateMap< OrderModel,OrderDto >();
        }

    }
    public class ModelClientProfile : Profile
    {
        public ModelClientProfile()
        {
            CreateMap<ClientModel, ClientDto>();
            CreateMap<ClientDto, ClientModel>();
        }
    }

    public class MapperConvert
    {
        public static IList<ClientModel> Map(IList<ClientDto> clientDto)
        {
            IList<ClientModel> clientModel = Mapper.Map<IList<ClientModel>>(clientDto);
            return clientModel;
        }
        public static ClientModel Map(ClientDto clientDto)
        {
            ClientModel clientModel = Mapper.Map<ClientModel>(clientDto);
            return clientModel;
        }
        public static ClientDto Map(ClientModel clientModel)
        {
            ClientDto clientDto = Mapper.Map<ClientDto>(clientModel);
            return clientDto;
        }
        public static IList<ClientDto> Map(IList<ClientModel> clientModel)
        {
            IList<ClientDto> clientDto = Mapper.Map<IList<ClientDto>>(clientModel);
            return clientDto;
        }
      

        public static IList<OrderModel> Map(IList<OrderDto> orderDto)
        {
            IList<OrderModel> orderModel = Mapper.Map<IList<OrderModel>>(orderDto);
            return orderModel;
        }
        public static OrderModel Map(OrderDto orderDto)
        {
            OrderModel orderModel = Mapper.Map<OrderModel>(orderDto);
            return orderModel;
        }

        public static IList<OrderDto> Map(IList<OrderModel> ordeModel)
        {
            IList<OrderDto> orderDto = Mapper.Map<IList<OrderDto>>(ordeModel);
            return orderDto;
        }
        public static OrderDto Map(OrderModel ordeModel)
        {
            OrderDto orderDto = Mapper.Map<OrderDto>(ordeModel);
            return orderDto;
        }
    }
}