using MySample.Domain.Entities;
using MySample.Domain.Interfaces.Repositories;
using System.Linq;

namespace MySample.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public Cliente GetByCpf(string cpf)
        {
            return Db.Clientes.Where(c => c.Cpf == cpf).FirstOrDefault();
        }
    }
}
