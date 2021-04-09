using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioImperio.DAL.Modelos
{
    public class ProfessorMateriaTurma
    {
        public int Id { get; set; }
        public string Turma { get; set; }
        public string Materia { get; set; }
        public string Professor { get; set; }
    }
}
