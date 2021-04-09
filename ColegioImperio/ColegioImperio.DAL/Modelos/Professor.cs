using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ColegioImperio.DAL.Modelos
{
    public class Professor 
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public string Email{ get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public int Status { get; set; }
        public string FuncionarioCadastro { get; set; }
        public string FuncionarioAlteracao { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtAlteracao { get; set; }
        public List<int> MateriasTurmas { get; set; }
    }
}

