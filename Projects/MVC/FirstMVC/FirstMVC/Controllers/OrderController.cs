using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Domain;
using Domain.DTO;
using Repository.Interfaces;

namespace FirstMVC.Controllers
{
    public class OrderController : Controller
    {
        private static int index = 1;
        private readonly IRepository<Entity> _repository;

        public OrderController(IRepository<Entity> repository)
        {
            _repository = repository;
        }
        // GET: Order
        public ActionResult Index()
        {
            IList<Order> orders = _repository.GetPaged<Order>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 10 });// _repository.All.OfType<Order>().ToList();
            IList<OrderDto> ordersDto = Mapper.Map<IList<OrderDto>>(orders);

            return View(ordersDto);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var ordDto = Mapper.Map<OrderDto>(_repository.FindById<Order>(id));
            return View(ordDto);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            OrderDto orderdto = new OrderDto();
            orderdto.Clients = Mapper.Map<IList<ClientDto>>(_repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 1000 }).ToList());//_repository.All.OfType<Client>().ToList()
            return View(orderdto);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderDto orddto)
        {
            try
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            var ordDto = Mapper.Map<OrderDto>(_repository.FindById<Order>(id));
            ordDto.Clients = Mapper.Map<IList<ClientDto>>(_repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 1000 }).ToList());//_repository.All.OfType<Client>().ToList()
            return View(ordDto);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderDto orddto)
        {
            try
            {
                // TODO: Add update logic here
                var ord = Mapper.Map<Order>(orddto);
                ord.Client = (Client)_repository.FindById<Client>(orddto.ClientId);
                _repository.Update<Order>(ord);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            var orddto = Mapper.Map<OrderDto>(_repository.FindById<Order>(id));
            return View(orddto);
        }

        // POST: Order/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(_repository.FindById<Order>(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
