using System.Data.SqlClient;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Request;

namespace TechHomeApi.Data.Repository
{
    public class ComodoRepository
    {
        string _connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

        public List<ComodoEntity> GetComodo(int id_casa)
        {
            List<ComodoEntity> list = new List<ComodoEntity>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Select id,nome from tb_comodo where id_casa = @id_casa";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@id_casa", id_casa);
                        // Execute a consulta e obtenha um leitor de dados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verifique se há linhas retornadas
                            if (reader.HasRows)
                            {
                                // Itere sobre as linhas retornadas
                                while (reader.Read())
                                {
                                    // Acesse os dados das colunas pelo nome da coluna ou pelo índice
                                    list.Add(new ComodoEntity { id = reader.GetInt32(reader.GetOrdinal("id")), name = reader.GetString(reader.GetOrdinal("Nome")) });
                                }
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
            return list;
        }
        public bool CreateComodo(ComodoPostRequest casa)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "insert into tb_comodo(nome,id_casa) values(@nome,@id_casa)";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@id_casa", casa.id_casa);
                        command.Parameters.AddWithValue("@nome", casa.name);
                        // Execute a consulta e obtenha um leitor de dados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verifique se há linhas retornadas
                            if (reader.RecordsAffected == 1)
                            {
                                // Itere sobre as linhas retornadas
                                sucess = true;
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
            return sucess;
        }

        public bool UpdateComodo(int id, string name)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Update tb_comodo set nome = @nome where id = @id";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {

                        command.Parameters.AddWithValue("@nome", name);
                        command.Parameters.AddWithValue("@id", id);
                        // Execute a consulta e obtenha um leitor de dados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verifique se há linhas retornadas
                            if (reader.RecordsAffected == 1)
                            {
                                // Itere sobre as linhas retornadas
                                sucess = true;
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
            return sucess;
        }

        public bool DeleteComodo(int id)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "delete from tb_comodo where id = @id";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);
                        // Execute a consulta e obtenha um leitor de dados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verifique se há linhas retornadas
                            if (reader.RecordsAffected == 1)
                            {
                                // Itere sobre as linhas retornadas
                                sucess = true;
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
            return sucess;
        }
    }
}
