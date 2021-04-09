using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColegioImperio.DAL.Modelos;


namespace ColegioImperio.DAL.Conexao
{
    public class SalaDAL : Conexao
    {
        public void Cadastrar(Sala sala)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Sala (Cod_Sala, Andar_Sala) VALUES (@Codigo, @Andar)", Conn);
                Cmd.Parameters.AddWithValue("@Codigo", sala.Codigo);
                Cmd.Parameters.AddWithValue("@Andar", sala.Andar);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar sala" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public void Editar(Sala sala)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE Sala SET Cod_Sala = @Codigo, Andar_Sala = @Andar WHERE Id_Sala = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", sala.Id);
                Cmd.Parameters.AddWithValue("@Andar", sala.Andar);
                Cmd.Parameters.AddWithValue("@Codigo", sala.Codigo);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar sala" + ex.Message);
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
                Cmd = new SqlCommand("DELETE Sala WHERE Id_Sala= @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Sala " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Sala Selecionar(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Sala WHERE Id_Sala = @Id", Conn);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                   Sala sala = new Sala();
                    sala.Id = Convert.ToInt32(Dr["Id_Sala"]);
                    sala.Andar = Convert.ToString(Dr["Andar_Sala"]);
                    sala.Codigo = Convert.ToString(Dr["Cod_Sala"]);
                    return sala;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar Sala " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Sala> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Sala", Conn);
                Dr = Cmd.ExecuteReader();
                List<Sala> lista = new List<Sala>();
                while (Dr.Read())
                {
                    Sala sala = new Sala();
                    sala.Id = Convert.ToInt32(Dr["Id_Sala"]);
                    sala.Andar = Convert.ToString(Dr["Andar_sala"]);
                    sala.Codigo = Convert.ToString(Dr["Cod_Sala"]);
                    lista.Add(sala);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar salas " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
