using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DAL.Conexao
{
    public class TurmaDAL : Conexao
    {
        public void Cadastrar(Turma turma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO TURMA (Id_Sala, Cod_Turma, Turno_Turma, Id_Funcionario_Cadastro) OUTPUT INSERTED.Id_Turma VALUES (@Sala, @Cod, @Turno, @Funcionario)", Conn);
                Cmd.Parameters.AddWithValue("@Sala", turma.Sala);
                Cmd.Parameters.AddWithValue("@Cod", turma.Cod);
                Cmd.Parameters.AddWithValue("@Turno", turma.Turno);
                Cmd.Parameters.AddWithValue("@Funcionario", turma.FuncionarioCadastro);

                int IdTurma = Convert.ToInt32(Cmd.ExecuteScalar());

                foreach(int IdMateria in turma.Materias)
                {
                    Cmd = new SqlCommand("INSERT INTO MATERIA_TURMA (Id_Turma, Id_Materia) VALUES (@Turma, @Materia)", Conn);
                    Cmd.Parameters.AddWithValue("@Turma", IdTurma);
                    Cmd.Parameters.AddWithValue("@Materia", IdMateria);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Editar(Turma turma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Turma SET Id_Sala = @Sala, Cod_Turma = @Codigo, Turno_Turma = @Turno, Status_Turma = @Status, Id_Funcionario_Alteracao = @Funcionario, Dt_Alteracao = @DtAlteracao WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", turma.Id);
                Cmd.Parameters.AddWithValue("@Sala", turma.Sala);
                Cmd.Parameters.AddWithValue("@Codigo", turma.Cod);
                Cmd.Parameters.AddWithValue("@Turno", turma.Turno);
                Cmd.Parameters.AddWithValue("@Funcionario", Convert.ToInt32(turma.FuncionarioAlteracao));
                Cmd.Parameters.AddWithValue("@DtAlteracao", DateTime.Now);
                Cmd.Parameters.AddWithValue("@Status", turma.Status);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM Materia_Turma WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", turma.Id);
                Cmd.ExecuteNonQuery();

                foreach (int IdMateria in turma.Materias)
                {
                    Cmd = new SqlCommand("INSERT INTO MATERIA_TURMA (Id_Turma, Id_Materia) VALUES (@Turma, @Materia)", Conn);
                    Cmd.Parameters.AddWithValue("@Turma", turma.Id);
                    Cmd.Parameters.AddWithValue("@Materia", IdMateria);
                    Cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar Turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Deletar(int IdTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Materia_Turma FROM Materia_Turma WHERE Id_Turma = @Turma", Conn);
                Cmd.Parameters.AddWithValue("@Turma", IdTurma);
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
                foreach(int item in IdMateriasTurmas)
                {
                    Cmd = new SqlCommand("DELETE FROM Professor_Materia_Turma WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                    Cmd.Parameters.AddWithValue("@MateriaTurma", item);
                    Cmd.ExecuteNonQuery();

                    Cmd = new SqlCommand("DELETE FROM Notas_Aluno_MaMateria_Turma WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                    Cmd.Parameters.AddWithValue("@MateriaTurma", item);
                    Cmd.ExecuteNonQuery();
                }

                Cmd = new SqlCommand("DELETE FROM Materia_Turma WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", IdTurma);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM ALUNO_TURMA WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", IdTurma);
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("DELETE FROM Turma WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", IdTurma);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
       public Turma Selecionar(int IdTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Turma WHERE Id_Turma = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", IdTurma);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Turma turma = new Turma();
                    turma.Id = Convert.ToInt32(Dr["Id_Turma"]);
                    turma.Sala = Convert.ToInt32(Dr["Id_Sala"]);
                    turma.Cod = Convert.ToString(Dr["Cod_Turma"]);
                    turma.Turno = Convert.ToString(Dr["Turno_Turma"]);
                    turma.Status = Convert.ToInt32(Dr["Status_Turma"]);
                    FecharConexao();
                    AbrirConexao();
                    
                    Cmd = new SqlCommand("SELECT * FROM Materia_Turma WHERE Id_Turma = @Id", Conn);
                    Cmd.Parameters.AddWithValue("@Id", IdTurma);


                    SqlDataReader DrMaterias = Cmd.ExecuteReader();
                    List<int> materias = new List<int>();
                    while (DrMaterias.Read()) {
                        materias.Add(Convert.ToInt32(DrMaterias["Id_Materia"]));   
                    }
                    turma.Materias = materias;
                    return turma;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Turma> ListarAtivos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Turma, Id_Sala, Cod_Turma, Turno_Turma, Status_Turma, Dt_Cadastro, Dt_Alteracao, Cadastro.Nome_Funcionario as [Funcionario Cadastro], Alteracao.Nome_Funcionario as [Funcionario Alteracao] FROM TURMA INNER JOIN FUNCIONARIO as Cadastro on Cadastro.Id_Funcionario = TURMA.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO as Alteracao on Alteracao.Id_Funcionario = TURMA.Id_Funcionario_Alteracao WHERE Status_Turma = 1", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherTurma();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar turmas ativas" +ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Turma> ListarInativos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Turma, Id_Sala, Cod_Turma, Turno_Turma, Status_Turma, Dt_Cadastro, Dt_Alteracao, Cadastro.Nome_Funcionario as [Funcionario Cadastro], Alteracao.Nome_Funcionario as [Funcionario Alteracao] FROM TURMA INNER JOIN FUNCIONARIO as Cadastro on Cadastro.Id_Funcionario = TURMA.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO as Alteracao on Alteracao.Id_Funcionario = TURMA.Id_Funcionario_Alteracao WHERE Status_Turma = 0", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherTurma();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar turmas ativas" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Turma> PreencherTurma()
        {
            List<Turma> lista = new List<Turma>();

            while (Dr.Read())
            {
                Turma turma = new Turma();
                turma.Id = Convert.ToInt32(Dr["Id_Turma"]);
                turma.Sala = Convert.ToInt32(Dr["Id_Sala"]);
                turma.Cod = Convert.ToString(Dr["Cod_Turma"]);
                turma.Turno = Convert.ToString(Dr["Turno_Turma"]);
                turma.Status = Convert.ToInt32(Dr["Status_Turma"]);
                turma.FuncionarioAlteracao = (Dr["Funcionario Alteracao"] == DBNull.Value) ? "" : Convert.ToString(Dr["Funcionario Alteracao"]);
                turma.FuncionarioCadastro = Convert.ToString(Dr["Funcionario Cadastro"]);
                turma.DataCadastro = Convert.ToDateTime(Dr["Dt_Cadastro"]);
                turma.DataAlteracao = (Dr["Dt_Alteracao"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Dr["Dt_Alteracao"]);
                lista.Add(turma);
            }
            return lista;
        }
        public List<Turma> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Turma, Id_Sala, Cod_Turma, Turno_Turma, Status_Turma, Dt_Cadastro, Dt_Alteracao, Cadastro.Nome_Funcionario as [Funcionario Cadastro], Alteracao.Nome_Funcionario as [Funcionario Alteracao] FROM TURMA INNER JOIN FUNCIONARIO as Cadastro on Cadastro.Id_Funcionario = TURMA.Id_Funcionario_Cadastro LEFT JOIN FUNCIONARIO as Alteracao on Alteracao.Id_Funcionario = TURMA.Id_Funcionario_Alteracao", Conn);
                Dr = Cmd.ExecuteReader();
                return PreencherTurma();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar turmas "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
