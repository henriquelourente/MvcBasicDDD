using AutoMapper;
using MySample.Application.ViewModels;
using MySample.Domain.Entities;
using MySample.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace MySample.Application
{
    public class ClienteAppService : IClienteAppService
    {
        IClienteRepository _repository;

        public ClienteAppService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void Add(ClienteViewModel cliente)
        {
            var clienteAdd = Mapper.Map<ClienteViewModel, Cliente>(cliente);
            _repository.Add(clienteAdd);
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_repository.GetById(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_repository.GetAll());
        }

        public void Update(ClienteViewModel cliente)
        {
            var clienteUpdt = Mapper.Map<ClienteViewModel, Cliente>(cliente);
            _repository.Update(clienteUpdt);
        }

        public void Remove(ClienteViewModel cliente)
        {
            var clienteRmv = Mapper.Map<ClienteViewModel, Cliente>(cliente);
            _repository.Remove(clienteRmv.ClienteId);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
