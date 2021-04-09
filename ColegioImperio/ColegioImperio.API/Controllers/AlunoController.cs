using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.API.Controllers
{
    public class AlunoController : ApiController
    {

        // GET: api/Aluno/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                AlunoDAL alunoDAL = new AlunoDAL();

                var aluno = alunoDAL.Selecionar(id);

                if(aluno != null)
                {
                    return Ok(aluno);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
