using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DAL.Conexao
{
    public class NotasDAL : Conexao
    {
        public void CadastrarNota(Notas notas)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO NOTAS_ALUNO_MATERIA_TURMA(Id_Aluno, Id_Materia_Turma, Notas_Aluno, Faltas_Aluno) VALUES (@Aluno, @Materia, @Notas, @Faltas)", Conn);
                Cmd.Parameters.AddWithValue("@Aluno", notas.Aluno);
                Cmd.Parameters.AddWithValue("@Materia", notas.Materia);
                Cmd.Parameters.AddWithValue("@Notas", notas.Nota);
                Cmd.Parameters.AddWithValue("@Faltas", notas.Faltas);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar nota "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void EditarNota(Notas notas)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE NOTAS_ALUNO_MATERIA_TURMA SET Id_Aluno = @Aluno, Id_Materia_Turma = @Materia, Notas_Aluno = @Notas, Faltas_Aluno = @Faltas WHERE Id_Nota = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", notas.Id);
                Cmd.Parameters.AddWithValue("@Aluno", notas.Aluno);
                Cmd.Parameters.AddWithValue("@Materia", notas.Materia);
                Cmd.Parameters.AddWithValue("@Notas", notas.Nota);
                Cmd.Parameters.AddWithValue("@Faltas", notas.Faltas);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar nota "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Notas SelecionarNota(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT NOTA.Id_Nota, ALUNO.Id_Aluno, TURMA.Id_Turma, MT.Id_Materia_Turma, NOTA.Notas_Aluno, NOTA.Faltas_Aluno FROM NOTAS_ALUNO_MATERIA_TURMA AS NOTA INNER JOIN ALUNO ON ALUNO.Id_Aluno = NOTA.Id_Aluno INNER JOIN MATERIA_TURMA AS MT ON MT.Id_Materia_Turma = NOTA.Id_Materia_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma WHERE NOTA.Id_Nota = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Notas notas = new Notas();
                    notas.Id = Convert.ToInt32(Dr["Id_Nota"]); notas.Aluno = Convert.ToString(Dr["Id_Aluno"]);
                    notas.Turma = Convert.ToString(Dr["Id_Turma"]);
                    notas.Materia = Convert.ToString(Dr["Id_Materia_Turma"]);
                    if (Dr["Notas_Aluno"] != DBNull.Value) notas.Nota = Convert.ToDecimal(Dr["Notas_Aluno"]);
                    notas.Faltas = (Dr["Faltas_Aluno"] != DBNull.Value) ? Convert.ToInt32(Dr["Faltas_Aluno"]) : 0;

                    return notas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar nota "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Notas> ListarAlunosNotasGrid()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT NOTA.Id_Nota, ALUNO.Nome_Aluno, TURMA.Cod_Turma, MATERIA.Nome_Materia, NOTA.Notas_Aluno, NOTA.Faltas_Aluno FROM NOTAS_ALUNO_MATERIA_TURMA AS NOTA INNER JOIN ALUNO ON ALUNO.Id_Aluno = NOTA.Id_Aluno INNER JOIN MATERIA_TURMA AS MT ON MT.Id_Materia_Turma = NOTA.Id_Materia_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma", Conn);
                return PreencherAlunoNotasGrid();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar turmas" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Notas> ListarAlunosNotasGrid (int IdTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT NOTA.Id_Nota, ALUNO.Nome_Aluno, TURMA.Cod_Turma, MATERIA.Nome_Materia, NOTA.Notas_Aluno, NOTA.Faltas_Aluno FROM NOTAS_ALUNO_MATERIA_TURMA AS NOTA INNER JOIN ALUNO ON ALUNO.Id_Aluno = NOTA.Id_Aluno INNER JOIN MATERIA_TURMA AS MT ON MT.Id_Materia_Turma = NOTA.Id_Materia_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma WHERE MT.Id_Turma = @Turma", Conn);
                Cmd.Parameters.AddWithValue("@Turma", IdTurma);
                return PreencherAlunoNotasGrid();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar turmas"+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Notas> ListarAlunoMateriaNotasTurma (int IdTurma, int IdAluno, int IdMateria)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT NOTA.Id_Nota, ALUNO.Nome_Aluno, TURMA.Cod_Turma, MATERIA.Nome_Materia, NOTA.Notas_Aluno, NOTA.Faltas_Aluno FROM NOTAS_ALUNO_MATERIA_TURMA AS NOTA INNER JOIN ALUNO ON ALUNO.Id_Aluno = NOTA.Id_Aluno INNER JOIN MATERIA_TURMA AS MT ON MT.Id_Materia_Turma = NOTA.Id_Materia_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma WHERE MT.Id_Turma = @Turma and NOTA.Id_Aluno = @Aluno and MT.Id_Materia_Turma = @Materia", Conn);
                Cmd.Parameters.AddWithValue("@Turma", IdTurma);
                Cmd.Parameters.AddWithValue("@Aluno", IdAluno);
                Cmd.Parameters.AddWithValue("@Materia", IdMateria);
                return PreencherAlunoNotasGrid();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar notas do aluno nas matérias " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }

        }
        public List<Notas> ListarMateriaNotasTurma(int IdTurma, int IdAluno)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT NOTA.Id_Nota, ALUNO.Nome_Aluno, TURMA.Cod_Turma, MATERIA.Nome_Materia, NOTA.Notas_Aluno, NOTA.Faltas_Aluno FROM NOTAS_ALUNO_MATERIA_TURMA AS NOTA INNER JOIN ALUNO ON ALUNO.Id_Aluno = NOTA.Id_Aluno INNER JOIN MATERIA_TURMA AS MT ON MT.Id_Materia_Turma = NOTA.Id_Materia_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma WHERE MT.Id_Turma = @Turma and NOTA.Id_Aluno = @Aluno", Conn);
                Cmd.Parameters.AddWithValue("@Turma", IdTurma);
                Cmd.Parameters.AddWithValue("@Aluno", IdAluno);
                return PreencherAlunoNotasGrid();
                
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar notas do aluno nas matérias "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Notas> PreencherAlunoNotasGrid()
        {
            Dr = Cmd.ExecuteReader();
            List<Notas> Lista = new List<Notas>();
            while (Dr.Read())
            {
                Notas notas = new Notas();
                notas.Id = Convert.ToInt32(Dr["Id_Nota"]);
                notas.Aluno = Convert.ToString(Dr["Nome_Aluno"]);
                notas.Turma = Convert.ToString(Dr["Cod_Turma"]);
                notas.Materia = Convert.ToString(Dr["Nome_Materia"]);
                if (Dr["Notas_Aluno"] != DBNull.Value) notas.Nota = Convert.ToDecimal(Dr["Notas_Aluno"]);
                notas.Faltas = (Dr["Faltas_Aluno"] != DBNull.Value) ? Convert.ToInt32(Dr["Faltas_Aluno"]) : 0;

                Lista.Add(notas);
            }

            return Lista;
        }
        public List<MateriaTurma> ListarMateriasTurma(int Turma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT MT.Id_Materia_Turma, M.Nome_Materia FROM MATERIA_TURMA AS MT INNER JOIN MATERIA AS M ON M.Id_Materia = MT.Id_Materia INNER JOIN TURMA AS T ON T.Id_Turma = MT.Id_Turma WHERE T.Id_Turma = @Turma", Conn);
                Cmd.Parameters.AddWithValue("@Turma", Turma);
                Dr = Cmd.ExecuteReader();
                List<MateriaTurma> Lista = new List<MateriaTurma>();
                while (Dr.Read())
                {
                    MateriaTurma materiaTurma = new MateriaTurma();
                    materiaTurma.Id = Convert.ToInt32(Dr["Id_Materia_Turma"]);
                    materiaTurma.Materia = Convert.ToString(Dr["Nome_Materia"]);
                    Lista.Add(materiaTurma);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar matérias da turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Aluno> ListarAlunosTurma(int Turma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT A.Id_Aluno, Nome_Aluno FROM ALUNO AS A INNER JOIN ALUNO_TURMA AS AT ON AT.Id_Aluno = A.Id_Aluno WHERE Id_Turma = @Turma", Conn);
                Cmd.Parameters.AddWithValue("@Turma", Turma);
                Dr = Cmd.ExecuteReader();
                List<Aluno> Lista = new List<Aluno>();
                while (Dr.Read())
                {
                    Aluno aluno = new Aluno();
                    aluno.Id = Convert.ToInt32(Dr["Id_Aluno"]);
                    aluno.Nome = Convert.ToString(Dr["Nome_Aluno"]);
                    Lista.Add(aluno);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar alunos da turma "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Notas> ListarNotasAluno(int Aluno)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Materia_Turma FROM NOTAS_ALUNO_MATERIA_TURMA WHERE Id_Aluno = @Aluno", Conn);
                Cmd.Parameters.AddWithValue("@Aluno", Aluno);
                Dr = Cmd.ExecuteReader();
                List<int> Materias = new List<int>();

                while (Dr.Read())
                {
                    Materias.Add(Convert.ToInt32(Dr["Id_Materia_Turma"]));
                }
                FecharConexao();
                AbrirConexao();

                List<Notas> Lista = new List<Notas>();
                foreach (int materia in Materias)
                {
                    Cmd = new SqlCommand("SELECT nota.Id_Nota, ALUNO.Nome_Aluno, materia.Nome_Materia, turma.Cod_Turma, nota.Notas_Aluno, nota.Faltas_Aluno, AVG(Notas_Aluno) as [Media] FROM NOTAS_ALUNO_MATERIA_TURMA as nota INNER JOIN ALUNO ON ALUNO.Id_Aluno = nota.Id_Aluno INNER JOIN MATERIA_TURMA as MT ON MT.Id_Materia_Turma = nota.Id_Materia_Turma INNER JOIN TURMA ON TURMA.Id_Turma = MT.Id_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MT.Id_Materia WHERE nota.Id_Aluno = @Aluno AND nota.Id_Materia_Turma = @Materia GROUP BY ALUNO.Nome_Aluno, nota.Id_Nota, nota.Faltas_Aluno, MATERIA.Nome_Materia, nota.Notas_Aluno, turma.Cod_Turma", Conn);
                    Cmd.Parameters.AddWithValue("@Aluno", Aluno);
                    Cmd.Parameters.AddWithValue("@Materia", materia);
                    Dr = Cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        Notas notas = new Notas();
                        notas.Id = Convert.ToInt32(Dr["Id_Nota"]);
                        notas.Aluno = Convert.ToString(Dr["Nome_Aluno"]);
                        notas.Turma = Convert.ToString(Dr["Cod_Turma"]);
                        notas.Materia = Convert.ToString(Dr["Nome_Materia"]);
                        notas.Nota = Convert.ToDecimal(Dr["Notas_Aluno"]);
                        notas.Faltas = Convert.ToInt32(Dr["Faltas_Aluno"]);
                        notas.Media = Convert.ToDecimal(Dr["Media"]);
                        Lista.Add(notas);
                    }
                    FecharConexao();
                    AbrirConexao();
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar notas do aluno"+ex.Message);
            }
        }
    }
}
