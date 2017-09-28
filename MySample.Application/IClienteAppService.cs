using MySample.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MySample.Application
{
    public interface IClienteAppService
    {
        void Add(ClienteViewModel cliente);
        ClienteViewModel GetById(Guid id);
        IEnumerable<ClienteViewModel> GetAll();
        void Update(ClienteViewModel cliente);
        void Remove(ClienteViewModel cliente);
        void Dispose();
    }
}
