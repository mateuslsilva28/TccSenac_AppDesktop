using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ColegioImperio.DAL.Conexao
{
    public class Conexao
    {
        protected SqlConnection Conn;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;
        public void AbrirConexao()
        {
            try
            {
                Conn = new SqlConnection(@"Data Source=ADBRÁSTANQUINHO\SQLSERVER;Initial Catalog=ColegioImperio;Integrated Security=True");
                Conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao abrir conexão com banco de dados "+ex.Message);
            }
        }
        public void FecharConexao()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao fechar conexão com banco de dados "+ ex.Message);
            }
        }
    }
}
