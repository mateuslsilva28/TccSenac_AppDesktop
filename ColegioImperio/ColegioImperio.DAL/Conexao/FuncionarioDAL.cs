using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DAL.Conexao
{
    public class FuncionarioDAL : Conexao
    {
        public Funcionario VerificarLogin(string login, string senha)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Funcionario WHERE Email_Funcionario = @Login AND Senha_Funcionario = @Senha", Conn);
                Cmd.Parameters.AddWithValue("@Login", login);
                Cmd.Parameters.AddWithValue("@Senha", senha);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(Dr["Id_Funcionario"]);
                    funcionario.IdTipo = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    funcionario.Nome = Convert.ToString(Dr["Nome_Funcionario"]);
                    funcionario.Email = Convert.ToString(Dr["Email_Funcionario"]);
                    funcionario.Senha = Convert.ToString(Dr["Senha_Funcionario"]);
                    funcionario.Status = Convert.ToInt32(Dr["Status_Funcionario"]);
                    return funcionario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao verificar funcionário no sistema "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }

        }
        public void TrocarSenha(string login, string novaSenha)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE FUNCIONARIO SET Senha_Funcionario = @NovaSenha WHERE Email_Funcionario = @Login", Conn);
                Cmd.Parameters.AddWithValue("@Login", login);
                Cmd.Parameters.AddWithValue("@NovaSenha", novaSenha);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao trocar senha "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Cadastrar(Funcionario funcionario)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Funcionario (Id_Tipo_Funcionario, Nome_Funcionario, Email_Funcionario, Senha_Funcionario) VALUES (@IdTipo, @Nome, @Email, @Senha)", Conn);
                Cmd.Parameters.AddWithValue("@IdTipo", funcionario.IdTipo);
                Cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                Cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                Cmd.Parameters.AddWithValue("@Senha", funcionario.Senha);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar funcionário "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Editar(Funcionario funcionario)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE FUNCIONARIO SET Id_Tipo_Funcionario = @IdTipo, Nome_Funcionario = @Nome, Email_Funcionario = @Email, Senha_Funcionario = @Senha, Status_Funcionario = @Status WHERE Id_Funcionario = @Id", Conn);
              Cmd.Parameters.AddWithValue("@Id", funcionario.Id);
                Cmd.Parameters.AddWithValue("@IdTipo", funcionario.IdTipo);
                Cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                Cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                Cmd.Parameters.AddWithValue("@Senha", funcionario.Senha);
                Cmd.Parameters.AddWithValue("@Status", funcionario.Status);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar funcionário "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Deletar(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Funcionario SET Status_Funcionario = 0 WHERE Id_Funcionario = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao desativar funcionário "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Funcionario Selecionar (int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Funcionario WHERE Id_Funcionario = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(Dr["Id_Funcionario"]);
                    funcionario.IdTipo = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    funcionario.Nome = Convert.ToString(Dr["Nome_Funcionario"]);
                    funcionario.Email = Convert.ToString(Dr["Email_Funcionario"]);
                    funcionario.Senha = Convert.ToString(Dr["Senha_Funcionario"]);
                    funcionario.Status = Convert.ToInt32(Dr["Status_Funcionario"]);
                    return funcionario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar funcionário "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Funcionario> ListarTodos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Funcionario, F.Id_Tipo_Funcionario, Nome_Tipo_Funcionario, Nome_Funcionario, Email_Funcionario, Senha_Funcionario, Status_Funcionario FROM Funcionario AS F JOIN Tipo_Funcionario AS T ON F.Id_Tipo_Funcionario = T.Id_Tipo_Funcionario", Conn);
                Dr = Cmd.ExecuteReader();
                List<Funcionario> lista = new List<Funcionario>();
                while (Dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(Dr["Id_Funcionario"]);
                    funcionario.IdTipo = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    funcionario.NomeTipo = Convert.ToString(Dr["Nome_Tipo_Funcionario"]);
                    funcionario.Nome = Convert.ToString(Dr["Nome_Funcionario"]);
                    funcionario.Email = Convert.ToString(Dr["Email_Funcionario"]);
                    funcionario.Senha = Convert.ToString(Dr["Senha_Funcionario"]);
                    funcionario.Status = Convert.ToInt32(Dr["Status_Funcionario"]);

                    lista.Add(funcionario);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar funcionários "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Funcionario> ListarAtivos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Funcionario, F.Id_Tipo_Funcionario, Nome_Tipo_Funcionario, Nome_Funcionario, Email_Funcionario, Senha_Funcionario, Status_Funcionario FROM Funcionario AS F JOIN Tipo_Funcionario AS T ON F.Id_Tipo_Funcionario = T.Id_Tipo_Funcionario WHERE Status_Funcionario = 1", Conn);
                Dr = Cmd.ExecuteReader();
                List<Funcionario> lista = new List<Funcionario>();
                while (Dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(Dr["Id_Funcionario"]);
                    funcionario.IdTipo = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    funcionario.NomeTipo = Convert.ToString(Dr["Nome_Tipo_Funcionario"]);
                    funcionario.Nome = Convert.ToString(Dr["Nome_Funcionario"]);
                    funcionario.Email = Convert.ToString(Dr["Email_Funcionario"]);
                    funcionario.Senha = Convert.ToString(Dr["Senha_Funcionario"]);
                    funcionario.Status = Convert.ToInt32(Dr["Status_Funcionario"]);
                    lista.Add(funcionario);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar funcionários ativos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Funcionario> ListarInativos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Funcionario, F.Id_Tipo_Funcionario, Nome_Tipo_Funcionario, Nome_Funcionario, Email_Funcionario, Senha_Funcionario, Status_Funcionario FROM Funcionario AS F JOIN Tipo_Funcionario AS T ON F.Id_Tipo_Funcionario = T.Id_Tipo_Funcionario WHERE Status_Funcionario = 0", Conn);
                Dr = Cmd.ExecuteReader();
                List<Funcionario> lista = new List<Funcionario>();
                while (Dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(Dr["Id_Funcionario"]);
                    funcionario.IdTipo = Convert.ToInt32(Dr["Id_Tipo_Funcionario"]);
                    funcionario.NomeTipo = Convert.ToString(Dr["Nome_Tipo_Funcionario"]);
                    funcionario.Nome = Convert.ToString(Dr["Nome_Funcionario"]);
                    funcionario.Email = Convert.ToString(Dr["Email_Funcionario"]);
                    funcionario.Senha = Convert.ToString(Dr["Senha_Funcionario"]);
                    funcionario.Status = Convert.ToInt32(Dr["Status_Funcionario"]);
                    lista.Add(funcionario);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar funcionários inativos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
