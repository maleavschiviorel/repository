using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Repository.Interfaces;
using Domain.Domain;
using AutoMapper;
using BLL.DTO;

namespace BLL
{
    public class LogicOrderService : ILogicService<OrderDto>
    {
        private readonly IRepository<Entity> _repository;
        public LogicOrderService(IRepository<Entity> repository)
        {
            _repository = repository;
        }
        public IList<OrderDto> GetPage(int page, int pagesize) 
        {
            IList<Order> orders = _repository.GetPaged<Order>(new Domain.DomainUtils.PageData() { Page = page, PageSize = pagesize });
            IList<OrderDto> ordersDto = Mapper.Map<IList<OrderDto>>(orders);
            return ordersDto;
        }
        public OrderDto GetById(int id)
        {
            OrderDto ordDto = Mapper.Map<OrderDto>(_repository.FindById<Order>(id));
            return ordDto;
        }

        public OrderDto CreateObj()
        {
            BLL.DTO.OrderDto orderdto = new BLL.DTO.OrderDto();
            orderdto.AllClients = Mapper.Map<IList<ClientDto>>(_repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 10000 }).ToList());//_repository.All.OfType<Client>().ToList()
            return orderdto;
        }

        public void SaveObj(OrderDto orddto)
        {
            // TODO: Add insert logic here
            Order ord = new Order()
            {
                Material = orddto.Material,
                Quantity = orddto.Quantity,
                UnitPrice = orddto.UnitPrice,
                Client = (Client)_repository.FindById<Client>(orddto.ClientId)
            };
            _repository.Add(ord);

        }

        public OrderDto GetByIdForEdit(int id)
        {
            OrderDto orderdto = GetById(id);
            orderdto.AllClients = Mapper.Map<IList<ClientDto>>(_repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 10000 }).ToList());//_repository.All.OfType<Client>().ToList()
            return orderdto;
        }

        public void UpdateObj(OrderDto orddto)
        {
            var ord = Mapper.Map<Order>(orddto);
            ord.Client = (Client)_repository.FindById<Client>(orddto.ClientId);
            _repository.Update<Order>(ord);
        }

        public void DeleteObj(int id)
        {
            _repository.Delete(_repository.FindById<Order>(id));
        }
    }
}
