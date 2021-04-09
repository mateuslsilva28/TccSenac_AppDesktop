using ColegioImperio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ColegioImperio.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContatoController : ApiController
    {
        public IHttpActionResult Get([FromBody] Mensagem mensagem)
        {
            string body = string.Format(@"Nome: {0}<br/> Email: {1} <br/> Telefone: {2}<br/>Assunto: {3}<br/> Mensagem: {4} <br/> Enviado em: {5}", mensagem.Nome, mensagem.Email, mensagem.Telefone, mensagem.Assunto, mensagem.Comentario, DateTime.Now);

            SmtpClient smpt = new SmtpClient();
            //dados do servidor do email
            smpt.Host = "smtp.gmail.com";
            smpt.Port = 587;
            smpt.EnableSsl = true;
            smpt.UseDefaultCredentials = false;
            smpt.Credentials = new NetworkCredential("ti01senacsmp@gmail.com", "LUgiEw6u");

            MailMessage msg = new MailMessage();

            //remetente
            msg.From = new MailAddress("faahpodolski23@gmail.com");

            //destinatário
            msg.To.Add(new MailAddress("mateuslsilva28@gmail.com"));

            //assunto
            msg.Subject = "Contato via site - " + mensagem.Nome;
            //corpo do e-mail
            msg.Body = body;
            //indica que a msg é html
            msg.IsBodyHtml = true;

            try
            {
                smpt.Send(msg);

                return Ok(new Result() { Sucesso = true });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
