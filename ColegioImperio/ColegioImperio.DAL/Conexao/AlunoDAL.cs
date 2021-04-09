using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DAL.Conexao
{
    public class AlunoDAL : Conexao
    {
        public Aluno VerificarLogin(string cpf, string rg)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM ALUNO Where Cpf_Aluno = @cpf AND Rg_Aluno = @rg", Conn);
                Cmd.Parameters.AddWithValue("@cpf", cpf);
                Cmd.Parameters.AddWithValue("@rg", rg);
                //executa o comando e pega o resultado
                Dr = Cmd.ExecuteReader();

                if (Dr.Read()) //retornou valor?
                {
                    Aluno aluno = new Aluno();
                    aluno.Id = Convert.ToInt32(Dr["Id_Aluno"]);
                    aluno.Nome = Convert.ToString(Dr["Nome_Aluno"]);
                    aluno.Cpf = Convert.ToString(Dr["Cpf_Aluno"]);
                    aluno.Rg = Convert.ToString(Dr["Rg_Aluno"]);
                    return aluno;
                }
                else //se não retornou, não encontrou usuário, então retorna null
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao verificar login " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Inserir(Aluno aluno)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO ALUNO (Nome_Aluno, Nome_Pai, Nome_Mae, Celular_Aluno, Celular_Responsavel, Cpf_Aluno, Rg_Aluno, Id_Funcionario_Cadastro) OUTPUT INSERTED.Id_Aluno VALUES (@Nome, @Pai, @Mae, @Celular, @CelularResponsavel, @Cpf, @Rg, @Funcionario)", Conn);
                Cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                Cmd.Parameters.AddWithValue("@Pai", aluno.Pai);
                Cmd.Parameters.AddWithValue("@Mae", aluno.Mae);
                Cmd.Parameters.AddWithValue("@Celular", aluno.Celular);
                Cmd.Parameters.AddWithValue("@CelularResponsavel", aluno.CelularResponsavel);
                Cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                Cmd.Parameters.AddWithValue("@Rg", aluno.Rg);
                Cmd.Parameters.AddWithValue("@Funcionario", aluno.FuncionarioCadastro);
                int IdAluno = Convert.ToInt32(Cmd.ExecuteScalar());

                Cmd = new SqlCommand("INSERT INTO INFO_ALUNO (Id_Aluno, Escolaridade_Aluno, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua) VALUES (@Id, @Escolaridade, @Rua, @Numero, @Complemento, @Bairro, @Cep)", Conn);
                Cmd.Parameters.AddWithValue("@Id", IdAluno);
                Cmd.Parameters.AddWithValue("@Escolaridade", aluno.Escolaridade);
                Cmd.Parameters.AddWithValue("@Rua", aluno.Rua);
                Cmd.Parameters.AddWithValue("@Numero", aluno.Numero);
                Cmd.Parameters.AddWithValue("@Complemento", aluno.Complemento);
                Cmd.Parameters.AddWithValue("@Bairro", aluno.Bairro);
                Cmd.Parameters.AddWithValue("@Cep", aluno.Cep);
                Cmd.ExecuteNonQuery();

                foreach(int item in aluno.Turmas)
                {
                    Cmd = new SqlCommand("INSERT INTO ALUNO_TURMA (Id_Aluno, Id_Turma) VALUES (@Aluno, @Turma)", Conn);
                    Cmd.Parameters.AddWithValue("@Aluno", IdAluno);
                    Cmd.Parameters.AddWithValue("@Turma", item);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar aluno "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Editar(Aluno aluno)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE ALUNO SET Nome_Aluno = @Nome, Cpf_Aluno = @Cpf, Rg_Aluno = @Rg, Celular_Aluno = @Celular, Status_Aluno = @Status, Nome_Pai = @Pai, Nome_Mae = @Mae, Celular_Responsavel = @CelularResponsavel, Dt_Alteracao = @Dt_Alteracao, Id_Funcionario_Alteracao = @Funcionario WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", aluno.Id);
                Cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                Cmd.Parameters.AddWithValue("@Pai", aluno.Pai);
                Cmd.Parameters.AddWithValue("@Mae", aluno.Mae);
                Cmd.Parameters.AddWithValue("@Celular", aluno.Celular);
                Cmd.Parameters.AddWithValue("@CelularResponsavel", aluno.CelularResponsavel);
                Cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                Cmd.Parameters.AddWithValue("@Rg", aluno.Rg);
                Cmd.Parameters.AddWithValue("@Status", aluno.Status);
                Cmd.Parameters.AddWithValue("@Dt_Alteracao", DateTime.Now);
                Cmd.Parameters.AddWithValue("@Funcionario", aluno.FuncionarioAlteracao);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM INFO_ALUNO WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", aluno.Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("INSERT INTO INFO_ALUNO (Id_Aluno, Escolaridade_Aluno, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua) VALUES (@Id, @Escolaridade, @Rua, @Numero, @Complemento, @Bairro, @Cep)", Conn);
                Cmd.Parameters.AddWithValue("@Id", aluno.Id);
                Cmd.Parameters.AddWithValue("@Escolaridade", aluno.Escolaridade);
                Cmd.Parameters.AddWithValue("@Rua", aluno.Rua);
                Cmd.Parameters.AddWithValue("@Numero", aluno.Numero);
                Cmd.Parameters.AddWithValue("@Complemento", aluno.Complemento);
                Cmd.Parameters.AddWithValue("@Bairro", aluno.Bairro);
                Cmd.Parameters.AddWithValue("@Cep", aluno.Cep);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM ALUNO_TURMA WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", aluno.Id);
                Cmd.ExecuteNonQuery();

                foreach (int item in aluno.Turmas)
                {
                    Cmd = new SqlCommand("INSERT INTO ALUNO_TURMA (Id_Aluno, Id_Turma) VALUES (@Aluno, @Turma)", Conn);
                    Cmd.Parameters.AddWithValue("@Aluno", aluno.Id);
                    Cmd.Parameters.AddWithValue("@Turma", item);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar aluno "+ex.Message);
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
                Cmd = new SqlCommand("DELETE FROM INFO_ALUNO WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM NOTAS_ALUNO_MATERIA_TURMA WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM ALUNO_TURMA WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM ALUNO WHERE Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar aluno "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Aluno Selecionar(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Aluno.Id_Aluno,  Nome_Aluno, Cpf_Aluno, Rg_Aluno, Escolaridade_Aluno, Status_Aluno, Celular_Aluno, Nome_Pai, Nome_Mae, Celular_Responsavel, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua FROM ALUNO AS ALUNO LEFT JOIN INFO_ALUNO AS INFO ON INFO.Id_Aluno = Aluno.Id_Aluno WHERE Aluno.Id_Aluno = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Aluno aluno = new Aluno();
                    aluno.Id = Convert.ToInt32(Dr["Id_Aluno"]);
                    aluno.Nome = Convert.ToString(Dr["Nome_Aluno"]);
                    aluno.Cpf = Convert.ToString(Dr["Cpf_Aluno"]);
                    aluno.Rg = Convert.ToString(Dr["Rg_Aluno"]);
                    aluno.Escolaridade = Convert.ToString(Dr["Escolaridade_Aluno"]);
                    aluno.Status = Convert.ToInt32(Dr["Status_Aluno"]);
                    aluno.Celular = Convert.ToString(Dr["Celular_Aluno"]);
                    aluno.Pai = Convert.ToString(Dr["Nome_Pai"]);
                    aluno.Mae = Convert.ToString(Dr["Nome_Mae"]);
                    aluno.CelularResponsavel = Convert.ToString(Dr["Celular_Responsavel"]);
                    aluno.Rua = Convert.ToString(Dr["Rua_Aluno"]);
                    aluno.Numero = Convert.ToInt32(Dr["Numero_Rua"]);
                    aluno.Complemento = Convert.ToString(Dr["Complemento_Rua"]);
                    aluno.Bairro = Convert.ToString(Dr["Bairro_Rua"]);
                    aluno.Cep = Convert.ToString(Dr["Cep_Rua"]);
                    
                    FecharConexao();
                    AbrirConexao();
                    
                    Cmd = new SqlCommand("SELECT * FROM Aluno_Turma WHERE Id_Aluno = @Id", Conn);
                    Cmd.Parameters.AddWithValue("@Id", aluno.Id);
                    SqlDataReader DrTurma = Cmd.ExecuteReader();
                    
                    List<int> turmas = new List<int>();
                    while (DrTurma.Read())
                    {
                        turmas.Add(Convert.ToInt32(DrTurma["Id_Turma"]));
                    }
                    aluno.Turmas = turmas;
                    return aluno;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar aluno "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Aluno> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Aluno.Id_Aluno, Nome_Aluno, Cpf_Aluno, Rg_Aluno, Escolaridade_Aluno, Status_Aluno, Celular_Aluno, Nome_Pai, Nome_Mae, Celular_Responsavel, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario as [Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua FROM  ALUNO AS ALUNO INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = ALUNO.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = ALUNO.Id_Funcionario_Alteracao LEFT JOIN INFO_ALUNO AS INFO ON INFO.Id_Aluno = ALUNO.Id_Aluno", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar alunos "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Aluno> ListarAtivos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Aluno.Id_Aluno, Nome_Aluno, Cpf_Aluno, Rg_Aluno, Escolaridade_Aluno, Status_Aluno, Celular_Aluno, Nome_Pai, Nome_Mae, Celular_Responsavel, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario as [Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua FROM  ALUNO AS ALUNO INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = ALUNO.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = ALUNO.Id_Funcionario_Alteracao LEFT JOIN INFO_ALUNO AS INFO ON INFO.Id_Aluno = ALUNO.Id_Aluno WHERE Status_Aluno = 1", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar alunos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Aluno> ListarInativos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Aluno.Id_Aluno, Nome_Aluno, Cpf_Aluno, Rg_Aluno, Escolaridade_Aluno, Status_Aluno, Celular_Aluno, Nome_Pai, Nome_Mae, Celular_Responsavel, CADASTRO.Nome_Funcionario as [Funcionario Cadastro], ALTERACAO.Nome_Funcionario as [Funcionario Alteracao], Dt_Cadastro, Dt_Alteracao, Rua_Aluno, Numero_Rua, Complemento_Rua, Bairro_Rua, Cep_Rua FROM  ALUNO AS ALUNO INNER JOIN FUNCIONARIO AS CADASTRO ON CADASTRO.Id_Funcionario = ALUNO.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO AS ALTERACAO ON ALTERACAO.Id_Funcionario = ALUNO.Id_Funcionario_Alteracao LEFT JOIN INFO_ALUNO AS INFO ON INFO.Id_Aluno = ALUNO.Id_Aluno WHERE Status_Aluno = 0", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherCampos();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar alunos " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Aluno> PreencherCampos()
        {
            List<Aluno> Lista = new List<Aluno>();
            while (Dr.Read())
            {
                Aluno aluno = new Aluno();
                aluno.Id = Convert.ToInt32(Dr["Id_Aluno"]);
                aluno.Nome = Convert.ToString(Dr["Nome_Aluno"]);
                aluno.Cpf = Convert.ToString(Dr["Cpf_Aluno"]);
                aluno.Rg = Convert.ToString(Dr["Rg_Aluno"]);
                aluno.Escolaridade = Convert.ToString(Dr["Escolaridade_Aluno"]);
                aluno.Status = Convert.ToInt32(Dr["Status_Aluno"]);
                aluno.Celular = Convert.ToString(Dr["Celular_Aluno"]);
                aluno.Pai = Convert.ToString(Dr["Nome_Pai"]);
                aluno.Mae = Convert.ToString(Dr["Nome_Mae"]);
                aluno.CelularResponsavel = Convert.ToString(Dr["Celular_Responsavel"]);
                aluno.Rua = Convert.ToString(Dr["Rua_Aluno"]);
                aluno.Numero = Convert.ToInt32(Dr["Numero_Rua"]);
                aluno.Complemento = Convert.ToString(Dr["Complemento_Rua"]);
                aluno.Bairro = Convert.ToString(Dr["Bairro_Rua"]);
                aluno.Cep = Convert.ToString(Dr["Cep_Rua"]);
                aluno.FuncionarioCadastro = Convert.ToString(Dr["Funcionario Cadastro"]);
                aluno.FuncionarioAlteracao = (Dr["Funcionario Alteracao"] == DBNull.Value) ? "" : Convert.ToString(Dr["Funcionario Alteracao"]);
                aluno.DtCadastro = Convert.ToDateTime(Dr["Dt_Cadastro"]);
                aluno.DtAlteracao = (Dr["Dt_Alteracao"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Dr["Dt_Alteracao"]);
                Lista.Add(aluno);
            }
            return Lista;
        }
    }
}
