using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class Notas
    {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Turma { get; set; }
        public string Materia { get; set; }
        public decimal Nota { get; set; }
        public decimal Media { get; set; }
        public int Faltas { get; set; }
    }
}
