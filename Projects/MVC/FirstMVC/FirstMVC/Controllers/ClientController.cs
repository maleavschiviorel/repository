using AutoMapper;
using Domain.Domain;
using Domain.DTO;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ClientController : Controller
    {
        private static int index = 1;
        private readonly IRepository<Entity> _repository;

        public ClientController(IRepository<Entity> repository)
        {
            _repository = repository;
        }
        // GET: Client
        public ActionResult Index()
        {
            IList<Client> clients = _repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = 0, PageSize = 10 }); //_repository.All.OfType<Client>().ToList();
            IList<ClientDto> clientDto = Mapper.Map<IList<ClientDto>>(clients);

            return View(clientDto);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var cliDto = Mapper.Map<ClientDto>(_repository.FindById<Client>(id));
            return View(cliDto);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientDto clientDto)
        {
            try
            {
                // TODO: Add insert logic here
                Client cli = new Client()
                {
                    FirstName = clientDto.FirstName,
                    LastName = clientDto.LastName,
                    BirthDate = clientDto.BirthDate,
                    TypeOfClient = clientDto.TypeOfClient
                };
                _repository.Add(cli);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var cliDto = Mapper.Map<ClientDto>(_repository.FindById<Client>(id));
            return View(cliDto);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientDto cliDto)
        {
            try
            {
                // TODO: Add update logic here
                var cli = Mapper.Map<Client>(cliDto);
                _repository.Update<Client>(cli);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var clidto = Mapper.Map<ClientDto>(_repository.FindById<Client>(id));
            return View(clidto);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(_repository.FindById<Client>(id));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
