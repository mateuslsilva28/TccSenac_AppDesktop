using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DAL.Conexao
{
    public class MaterialDAL : Conexao
    {
        public void Cadastrar(Materia materia)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Materia(Nome_Materia, Id_Funcionario_Cadastro) VALUES (@Nome, @Funcionario)", Conn);
                Cmd.Parameters.AddWithValue("@Nome", materia.Nome);
                Cmd.Parameters.AddWithValue("@Funcionario", Convert.ToInt32(materia.FuncionarioCadastro));
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Materia" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Editar(Materia materia)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Materia SET Nome_Materia = @Nome, Id_Funcionario_Alteracao = @Funcionario, Dt_Alteracao = @DtAlteracao WHERE Id_Materia = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", materia.Id);
                Cmd.Parameters.AddWithValue("@Nome", materia.Nome);
                Cmd.Parameters.AddWithValue("@Funcionario", Convert.ToInt32(materia.FuncionarioAlteracao));
                Cmd.Parameters.AddWithValue("@DtAlteracao", DateTime.Now);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar matéria " + ex.Message);
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
                Cmd = new SqlCommand("SELECT Id_Materia_Turma FROM Materia_Turma WHERE Id_Materia = @Materia", Conn);
                Cmd.Parameters.AddWithValue("@Materia", Id);
                Dr = Cmd.ExecuteReader();
                List<int> IdMateriasTurmas = new List<int>();
                int id;
                while (Dr.Read())
                {
                    id = Convert.ToInt32(Dr["Id_Materia_Turma"]);
                    IdMateriasTurmas.Add(id);
                }
                FecharConexao();
                AbrirConexao();
                foreach (int item in IdMateriasTurmas)
                {
                    Cmd = new SqlCommand("DELETE FROM Professor_Materia_Turma WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                    Cmd.Parameters.AddWithValue("@MateriaTurma", item);
                    Cmd.ExecuteNonQuery();

                    Cmd = new SqlCommand("DELETE FROM NOTAS_ALUNO_MATERIA_TURMA WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                    Cmd.Parameters.AddWithValue("@MateriaTurma", item);
                    Cmd.ExecuteNonQuery();
                }

                Cmd = new SqlCommand("DELETE FROM Materia_Turma WHERE Id_Materia = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE Materia WHERE Id_Materia= @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Materia " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Materia Selecionar(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Materia WHERE Id_Materia = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Materia materia = new Materia();
                    materia.Id = Convert.ToInt32(Dr["Id_Materia"]);
                    materia.Nome = Convert.ToString(Dr["Nome_Materia"]);
                    materia.FuncionarioCadastro = Convert.ToString(Dr["Id_Funcionario_Cadastro"]);
                    materia.FuncionarioAlteracao = Convert.ToString(Dr["Id_Funcionario_Alteracao"]);
                    materia.DataCadastro = Convert.ToDateTime(Dr["Dt_Cadastro"]);
                    materia.DataAlteracao = Convert.ToDateTime(Dr["Dt_Alteracao"]);
                    return materia;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar matéria " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Materia> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Materia, Nome_Materia, Dt_Cadastro, Dt_Alteracao, Cadastro.Nome_Funcionario as [Funcionario Cadastro], Alteracao.Nome_Funcionario as [Funcionario Alteracao] FROM MATERIA INNER JOIN FUNCIONARIO as Cadastro on Cadastro.Id_Funcionario = MATERIA.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO as Alteracao on Alteracao.Id_Funcionario = MATERIA.Id_Funcionario_Alteracao", Conn);
                Dr = Cmd.ExecuteReader();
                List<Materia> lista = new List<Materia>();
                while (Dr.Read())
                {
                    Materia materia = new Materia();
                    materia.Id = Convert.ToInt32(Dr["Id_Materia"]);
                    materia.Nome = Convert.ToString(Dr["Nome_Materia"]);
                    materia.FuncionarioCadastro = Convert.ToString(Dr["Funcionario Cadastro"]);
                    materia.FuncionarioAlteracao = (Dr["Funcionario Alteracao"] == DBNull.Value) ? "" : Convert.ToString(Dr["Funcionario Alteracao"]);
                    materia.DataCadastro = Convert.ToDateTime(Dr["Dt_Cadastro"]);
                    if(Dr["Dt_Alteracao"]!=DBNull.Value) materia.DataAlteracao = Convert.ToDateTime(Dr["Dt_Alteracao"]);
                    lista.Add(materia);
                }
                
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar matérias " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}

