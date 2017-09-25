using System.Collections.Generic;
using BLL.Interfaces;
using Repository.Interfaces;
using Domain.Domain;
using AutoMapper;
using BLL.DTO;

namespace BLL
{
    public class LogicClientService : ILogicService<ClientDto>
    {
        private readonly IRepository<Entity> _repository;
        public LogicClientService(IRepository<Entity> repository)
        {
            _repository = repository;
        }
        public IList<ClientDto> GetPage(int page, int pagesize)
        {
            IList<Client> clients = _repository.GetPaged<Client>(new Domain.DomainUtils.PageData() { Page = page, PageSize = pagesize }); 
            IList<ClientDto> clientDto = Mapper.Map<IList<ClientDto>>(clients);
            return clientDto;
        }
        public ClientDto GetById(int id)
        {
            var client = _repository.FindById<Client>(id);
            var cliDto = Mapper.Map<ClientDto>(client);
            return cliDto;
        }

        public ClientDto CreateObj()
        {
            ClientDto cliDto = new ClientDto();
            return cliDto;
        }

        public void SaveObj(ClientDto clientDto)
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

        }

        public ClientDto GetByIdForEdit(int id)
        {
            var cliDto = Mapper.Map<ClientDto>(_repository.FindById<Client>(id));
            return cliDto;
        }

        public void UpdateObj(ClientDto cliDto)
        {
            var cli = Mapper.Map<Client>(cliDto);
            _repository.Update<Client>(cli);
        }

        public void DeleteObj(int id)
        {
            _repository.Delete(_repository.FindById<Client>(id));
        }
    }
}
