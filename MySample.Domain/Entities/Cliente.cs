using MySample.Domain.Validations;
using System;

namespace MySample.Domain.Entities
{
    public class Cliente 
    {
        public Guid ClienteId { get;  set; }
        public string Nome { get;  set; }
        public string Cpf { get;  set; }

        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Nome) && CpfValidation.IsValid(Cpf);
        }
    }
}
