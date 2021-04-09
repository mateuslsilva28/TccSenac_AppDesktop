using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class Turma
    {
        public int Id { get; set; }
        public int Sala { get; set; }
        public string Cod { get; set; }
        public string Turno { get; set; }
        public int Status { get; set; }
        public List<int> Materias { get; set; }
        public string FuncionarioCadastro { get; set; }
        public string FuncionarioAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
