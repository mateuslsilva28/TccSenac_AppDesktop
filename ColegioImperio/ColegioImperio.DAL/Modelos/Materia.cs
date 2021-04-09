using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class Materia
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string FuncionarioCadastro { get; set; }
        public string FuncionarioAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        
    }
}