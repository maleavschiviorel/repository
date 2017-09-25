using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Domain;
using Repository.Interfaces;
using BLL.Interfaces;
using BLL.DTO;
using FirstMVC.AutoMapDtoToModel;
using FirstMVC.Model;

namespace FirstMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogicService<OrderDto> _logicService;

        public OrderController(ILogicService<OrderDto> logicService)
        {
            _logicService = logicService;
        }
        // GET: Order
        public ActionResult Index()
        {
            IList<OrderDto> ordersDto = _logicService.GetPage(0, 10);
            return View(MapperConvert.Map(ordersDto));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var ordDto = _logicService.GetById(id);
            return View(MapperConvert.Map(ordDto));
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            OrderDto orderdto = _logicService.CreateObj();
            return View(MapperConvert.Map(orderdto));
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderModel ordmodel)
        {
            _logicService.SaveObj(MapperConvert.Map(ordmodel));
            return RedirectToAction("Index");
            return View();
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            var ordDto = _logicService.GetByIdForEdit(id);
            return View(MapperConvert.Map(ordDto));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderModel ordmodel)
        {
            _logicService.UpdateObj(MapperConvert.Map(ordmodel));
            return RedirectToAction("Index");
            return View();
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            var orddto = _logicService.GetById(id);
            return View(MapperConvert.Map(orddto));
        }

        // POST: Order/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            _logicService.DeleteObj(id);
            return RedirectToAction("Index");
            return View();
        }
    }
}
