using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColegioImperio.DAL.Modelos;


namespace ColegioImperio.DAL.Conexao
{
    public class ProfessorDAL : Conexao
    {
        /*        public Professor VerificarLogin(string login, string senha)
                {
                    try
                    {
                        AbrirConexao();
                        Cmd = new SqlCommand("SELECT * FROM Professor WHERE Email_Professor = @Login AND Senha_Professor = @Senha", Conn);
                        Cmd.Parameters.AddWithValue("@Login", login);
                        Cmd.Parameters.AddWithValue("@Senha", senha);
                        Dr = Cmd.ExecuteReader();

                        if (Dr.Read())
                        {
                            Professor Professor = new Professor();
                            Professor.Id = Convert.ToInt32(Dr["Id_Professor"]);
                            Professoro.Nome = Convert.ToString(Dr["Nome_Professor"]);
                            Professor.Email = Convert.ToString(Dr["Email_Professor"]);
                            Professor.Senha = Convert.ToString(Dr["Senha_Professor"]);
                            Professor.Cpf=   Convert.ToString(Dr["CPF_Professor"]);
                            Professor.Celular = Convert.ToString(Dr["Celular_Professor"]);
                           return Professor;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Erro ao verificar Login " + ex.Message);
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
                        Cmd = new SqlCommand("UPDATE Professor SET Senha_Professor = @NovaSenha WHERE Email_Professor = @Login", Conn);
                        Cmd.Parameters.AddWithValue("@Login", login);
                        Cmd.Parameters.AddWithValue("@NovaSenha", novaSenha);
                        Cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Erro ao trocar senha " + ex.Message);
                    }
                    finally
                    {
                        FecharConexao();
                    }
                }*/
        public int Cadastrar(Professor professor)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Professor(Nome_Professor, Area_Professor, Email_Professor,  Cpf_Professor, Celular_Professor, Id_Funcionario_Cadastro) OUTPUT INSERTED.Id_Professor VALUES (@Nome, @Area, @Email, @Cpf, @Celular, @Funcionario)", Conn);
                Cmd.Parameters.AddWithValue("@Nome", professor.Nome);
                Cmd.Parameters.AddWithValue("@Area", professor.Area);
                Cmd.Parameters.AddWithValue("@Email", professor.Email);
                Cmd.Parameters.AddWithValue("@Cpf", professor.CPF);
                Cmd.Parameters.AddWithValue("@Celular", professor.Celular);
                Cmd.Parameters.AddWithValue("@Funcionario", professor.FuncionarioCadastro);
                int IdProfessor = Convert.ToInt32(Cmd.ExecuteScalar());

                return IdProfessor;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar professor " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Editar(Professor professor)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Professor SET Nome_Professor = @Nome, Area_Professor = @Area, Email_Professor = @Email, Cpf_Professor = @Cpf, Celular_Professor = @Celular, Status_Professor = @Status, Id_Funcionario_Alteracao = @Funcionario, Dt_Alteracao = @DtAlteracao WHERE Id_Professor = @Id", Conn);
                Cmd.Parameters.AddWithValue("Id", professor.Id);
                Cmd.Parameters.AddWithValue("@Nome", professor.Nome);
                Cmd.Parameters.AddWithValue("@Area", professor.Area);
                Cmd.Parameters.AddWithValue("@Email", professor.Email);
                Cmd.Parameters.AddWithValue("@Cpf", professor.CPF);
                Cmd.Parameters.AddWithValue("@Celular", professor.Celular);
                Cmd.Parameters.AddWithValue("@Funcionario", Convert.ToInt32(professor.FuncionarioAlteracao));
                Cmd.Parameters.AddWithValue("@Status", professor.Status);
                Cmd.Parameters.AddWithValue("@DtAlteracao", DateTime.Now);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar professor " + ex.Message);
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
                Cmd = new SqlCommand("DELETE Professor_Materia_Turma WHERE Id_Professor = @Id", Conn);
                Cmd.Parameters.AddWithValue("Id", Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE Professor WHERE Id_Professor= @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Professor " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Professor Selecionar(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Professor, Nome_Professor, Area_Professor, Email_Professor, Cpf_Professor, Celular_Professor, Status_Professor FROM PROFESSOR WHERE Id_Professor = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Professor professor = new Professor();
                    professor.Id = Convert.ToInt32(Dr["Id_Professor"]);
                    professor.Nome = Convert.ToString(Dr["Nome_Professor"]);
                    professor.Area = Convert.ToString(Dr["Area_Professor"]);
                    professor.Email = Convert.ToString(Dr["Email_Professor"]);
                    professor.CPF = Convert.ToString(Dr["Cpf_Professor"]);
                    professor.Celular = Convert.ToString(Dr["Celular_Professor"]);
                    professor.Status = Convert.ToInt32(Dr["Status_Professor"]);

                    return professor;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar professor " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Professor> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT PROFESSOR.Id_Professor, Nome_Professor, Area_Professor, Email_Professor, Cpf_Professor, Celular_Professor, Status_Professor, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario[Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao FROM PROFESSOR INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = PROFESSOR.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = PROFESSOR.Id_Funcionario_Alteracao", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar todos os professores " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Professor> ListarAtivos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT PROFESSOR.Id_Professor, Nome_Professor, Area_Professor, Email_Professor, Cpf_Professor, Celular_Professor, Status_Professor, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario[Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao FROM PROFESSOR INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = PROFESSOR.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = PROFESSOR.Id_Funcionario_Alteracao WHERE Status_Professor = 1", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar professores ativos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Professor> ListarInativos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT PROFESSOR.Id_Professor, Nome_Professor, Area_Professor, Email_Professor, Cpf_Professor, Celular_Professor, Status_Professor, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario[Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao FROM PROFESSOR INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = PROFESSOR.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = PROFESSOR.Id_Funcionario_Alteracao WHERE Status_Professor = 0", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar professores inativos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Professor> PreencherCampos()
        {
            List<Professor> lista = new List<Professor>();
            while (Dr.Read())
            {
                Professor professor = new Professor();
                professor.Id = Convert.ToInt32(Dr["Id_Professor"]);
                professor.Nome = Convert.ToString(Dr["Nome_Professor"]);
                professor.Area = Convert.ToString(Dr["Area_Professor"]);
                professor.Email = Convert.ToString(Dr["Email_Professor"]);
                professor.Status = Convert.ToInt32(Dr["Status_Professor"]);
                professor.CPF = Convert.ToString(Dr["CPF_Professor"]);
                professor.Celular = Convert.ToString(Dr["Celular_Professor"]);
                professor.FuncionarioCadastro = Convert.ToString(Dr["Funcionario Cadastro"]);
                professor.FuncionarioAlteracao = (Dr["Funcionario Alteracao"] == DBNull.Value) ? "" : Convert.ToString(Dr["Funcionario Alteracao"]);
                professor.DtCadastro = Convert.ToDateTime(Dr["Dt_Cadastro"]);
                if (Dr["Dt_Alteracao"] != DBNull.Value) professor.DtAlteracao = Convert.ToDateTime(Dr["Dt_Alteracao"]);
                lista.Add(professor);
            }
            return lista;
        }
    }

}
