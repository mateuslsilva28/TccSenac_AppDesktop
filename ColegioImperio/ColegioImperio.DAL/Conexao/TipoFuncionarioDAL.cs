using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColegioImperio.DAL.Modelos;
using System.Data.SqlClient;

namespace ColegioImperio.DAL.Conexao
{
    public class TipoFuncionarioDAL : Conexao
    {
        public List<TipoFuncionario> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Tipo_Funcionario", Conn);
                Dr = Cmd.ExecuteReader();
                List<TipoFuncionario> Lista = new List<TipoFuncionario>();

                while (Dr.Read())
                {
                    TipoFuncionario tipoFuncionario = new TipoFuncionario();
                    tipoFuncionario.Id = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    tipoFuncionario.Tipo = Convert.ToString(Dr["Nome_Tipo_Funcionario"]);
                    Lista.Add(tipoFuncionario);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar tipos de funcionários "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }

        }
    }
}
