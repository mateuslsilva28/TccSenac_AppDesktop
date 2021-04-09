using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class Aluno
    {
        //Tabela Aluno
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string Celular { get; set; }
        public string CelularResponsavel { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int Status { get; set; }
        public string FuncionarioCadastro { get; set; }
        public string FuncionarioAlteracao { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtAlteracao { get; set; }

        //tabela INFO_ALUNO
        public string Escolaridade { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        //tabela TURMA_ALUNO
        public List<int> Turmas { get; set; }
    }
}
