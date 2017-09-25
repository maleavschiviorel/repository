using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Domain.Domain;
using FirstMVC.AutoMapDtoToModel;
using FirstMVC.Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ClientController : Controller
    {
        private static int index = 1;
        private readonly ILogicService<ClientDto> _logicService;

        public ClientController(ILogicService<ClientDto> logicService)
        {
            _logicService = logicService;
        }
        // GET: Client
        public ActionResult Index()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                IList<ClientDto> clientDto = _logicService.GetPage(0, 10);
                scope.Complete();
                return View(MapperConvert.Map(clientDto));
            }            
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var cliDto = _logicService.GetById(id);
            return View(MapperConvert.Map(cliDto));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientModel clientModel)
        {
            _logicService.SaveObj(MapperConvert.Map(clientModel));
            return RedirectToAction("Index");
            return View();
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var cliDto = _logicService.GetById(id);
            return View(MapperConvert.Map(cliDto));
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientModel clientModel)
        {
            _logicService.UpdateObj(MapperConvert.Map(clientModel));
            return RedirectToAction("Index");
            return View();
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var clidto = _logicService.GetById(id);
            return View(MapperConvert.Map(clidto));
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _logicService.DeleteObj(id);
            return RedirectToAction("Index");
            return View();
        }
    }
}
