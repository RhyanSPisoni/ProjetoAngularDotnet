using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dto
{
    public class UserDTO
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
    }
}