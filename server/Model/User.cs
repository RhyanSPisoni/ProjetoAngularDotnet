using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model
{
    public class User
    {
        [Key]
        public int codigo { get; set; }
        public required string nome { get; set; }
        public required string cpf { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }

    }
}