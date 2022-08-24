using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.API.Models
{
    public class Pessoa : Base
    {
        [Required]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
