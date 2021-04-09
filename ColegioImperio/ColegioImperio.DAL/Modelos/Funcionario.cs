using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string NomeTipo { get; set; }
        public int IdTipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
    }
}
