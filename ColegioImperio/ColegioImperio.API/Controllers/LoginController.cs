using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using ColegioImperio.API.JWT;
using ColegioImperio.API.Models;
using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.API.Controllers
{
    public class LoginController : ApiController
    {
        public IHttpActionResult Post([FromBody] Models.Login login)
        {
            try
            {
                if (login.Cpf != null && login.Rg != null)
                {
                    AlunoDAL alunoDAL = new AlunoDAL();

                    Aluno aluno = alunoDAL.VerificarLogin(login.Cpf, login.Rg);

                    if (aluno != null)
                    {
                        TokenGenerate tokenGenerate = new TokenGenerate();
                        Token token = tokenGenerate.CreateToken(login.Cpf);
                        return Ok(token);
                    }
                }

                return Unauthorized();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
