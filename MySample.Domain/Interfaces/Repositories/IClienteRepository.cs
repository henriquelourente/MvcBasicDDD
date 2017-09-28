using MySample.Domain.Entities;

namespace MySample.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente GetByCpf(string cpf);
    }
}
