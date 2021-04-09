using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ColegioImperio.API.Controllers
{
    public class NotasController : ApiController
    {
        // GET: api/Notas/5
        public IHttpActionResult Get(int Turma, int Aluno)
        {
            try
            {
                NotasDAL notasDAL = new NotasDAL();
                List<Notas> Notas = notasDAL.ListarMateriaNotasTurma(Turma, Aluno);

                return Ok(Notas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
