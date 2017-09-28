using FluentValidator;

namespace MySample.Domain.ValueObjects
{
    public class Cpf : Notifiable
    {
        public string Numero { get; set; }

        public Cpf(string numero)
        {
            Numero = numero;
        }
    }
}
