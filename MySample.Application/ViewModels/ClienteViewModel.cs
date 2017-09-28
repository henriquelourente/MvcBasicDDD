using System;
using System.ComponentModel.DataAnnotations;

namespace MySample.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cpf")]
        public string Cpf { get; set; }

        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
        }
    }
}
