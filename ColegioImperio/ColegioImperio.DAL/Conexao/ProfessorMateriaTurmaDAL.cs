using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColegioImperio.DAL.Modelos;
using System.Data.SqlClient;

namespace ColegioImperio.DAL.Conexao
{
    public class ProfessorMateriaTurmaDAL : Conexao
    {
        public ProfessorMateriaTurma VerificarMateriaProfessor(int MateriaTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Professor_Materia_Turma WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                Cmd.Parameters.AddWithValue("@MateriaTurma", MateriaTurma);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    return null;
                }
                else
                {
                    ProfessorMateriaTurma professorMateriaTurma = new ProfessorMateriaTurma();
                    return professorMateriaTurma;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao verificar matéria "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void CadastrarMateriaProfessor(ProfessorMateriaTurma professorMateriaTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Professor_Materia_Turma (Id_Professor, Id_Materia_Turma) VALUES (@Professor, @MateriaTurma)", Conn);
                Cmd.Parameters.AddWithValue("@Professor", Convert.ToInt32(professorMateriaTurma.Professor));
                Cmd.Parameters.AddWithValue("@MateriaTurma", professorMateriaTurma.Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar uma matéria para o professor "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void EditarMateriaProfessor(ProfessorMateriaTurma professorMateriaTurma, int MateriaTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Professor_Materia_Turma SET Id_Materia_Turma = @MateriaTurma WHERE Id_Professor = @Professor AND Id_Materia_Turma = @IdMateriaTurma", Conn);
                Cmd.Parameters.AddWithValue("@Professor", Convert.ToInt32(professorMateriaTurma.Professor));
                Cmd.Parameters.AddWithValue("@IdMateriaTurma", MateriaTurma);
                Cmd.Parameters.AddWithValue("@MateriaTurma", professorMateriaTurma.Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar matéria do professor "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void DeletarMateriaProfessor(int MateriaTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("DELETE Professor_Materia_Turma WHERE Id_Materia_Turma = @MateriaTurma", Conn);
                Cmd.Parameters.AddWithValue("@MateriaTurma", MateriaTurma);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar matéria do professor "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public ProfessorMateriaTurma SelecionarMateriaProfessor(int MateriaTurma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT  PMT.Id_Materia_Turma, TURMA.Id_Turma FROM PROFESSOR_MATERIA_TURMA AS PMT INNER JOIN MATERIA_TURMA ON MATERIA_TURMA.Id_Materia_Turma = PMT.Id_Materia_Turma INNER JOIN TURMA ON TURMA.Id_Turma = MATERIA_TURMA.Id_Turma WHERE PMT.Id_Materia_Turma = @MateriaTurma", Conn);
                Cmd.Parameters.AddWithValue("@MateriaTurma", MateriaTurma);
                Dr = Cmd.ExecuteReader();

                ProfessorMateriaTurma professorMateriaTurma = new ProfessorMateriaTurma();
                if (Dr.Read())
                {
                    professorMateriaTurma.Id = Convert.ToInt32(Dr["Id_Materia_Turma"]);
                    professorMateriaTurma.Turma = Convert.ToString(Dr["Id_Turma"]);
                    return professorMateriaTurma;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar matéria do professor "+ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<ProfessorMateriaTurma> ListarMateriasDoProfessor(int Professor)
        {
            AbrirConexao();
            Cmd = new SqlCommand("SELECT  PMT.Id_Materia_Turma, TURMA.Cod_Turma, MATERIA.Nome_Materia, PROFESSOR.Nome_Professor FROM PROFESSOR_MATERIA_TURMA AS PMT INNER JOIN PROFESSOR ON PROFESSOR.Id_Professor = PMT.Id_Professor INNER JOIN MATERIA_TURMA ON MATERIA_TURMA.Id_Materia_Turma = PMT.Id_Materia_Turma INNER JOIN TURMA ON TURMA.Id_Turma = MATERIA_TURMA.Id_Turma INNER JOIN MATERIA ON MATERIA.Id_Materia = MATERIA_TURMA.Id_Materia WHERE PMT.Id_Professor = @Professor", Conn);
            Cmd.Parameters.AddWithValue("@Professor", Professor);
            Dr = Cmd.ExecuteReader();

            List<ProfessorMateriaTurma> lista = new List<ProfessorMateriaTurma>();
            while (Dr.Read())
            {
                ProfessorMateriaTurma professorMateriaTurma = new ProfessorMateriaTurma();
                professorMateriaTurma.Id = Convert.ToInt32(Dr["Id_Materia_Turma"]);
                professorMateriaTurma.Turma = Convert.ToString(Dr["Cod_Turma"]);
                professorMateriaTurma.Materia = Convert.ToString(Dr["Nome_Materia"]);
                professorMateriaTurma.Professor = Convert.ToString(Dr["Nome_Professor"]);
                lista.Add(professorMateriaTurma);
            }
            return lista;
        }
        public List<ProfessorMateriaTurma> ListarMateriasDaTurma(int Turma)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT Id_Materia_Turma, MATERIA.Nome_Materia as [Nome Materia] FROM MATERIA_TURMA INNER JOIN MATERIA ON MATERIA.Id_Materia = MATERIA_TURMA.Id_Materia WHERE Id_Turma = @Turma", Conn);
                Cmd.Parameters.AddWithValue("@Turma", Turma);
                Dr = Cmd.ExecuteReader();

                List<ProfessorMateriaTurma> lista = new List<ProfessorMateriaTurma>();
                while (Dr.Read())
                {
                    ProfessorMateriaTurma professorMateriaTurma = new ProfessorMateriaTurma();
                    professorMateriaTurma.Id = Convert.ToInt32(Dr["Id_Materia_Turma"]);
                    professorMateriaTurma.Materia = Convert.ToString(Dr["Nome Materia"]);
                    lista.Add(professorMateriaTurma);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar matérias da turma " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
