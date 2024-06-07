using System.Data.SqlClient;
using TechHomeApi.Model.Entity;

namespace TechHomeApi.Data.Repository
{
    public class AparelhoRepository
    {
        string _connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        public List<AparelhoEntity> GetAparelhos(int id_comodo)
        {
            List<AparelhoEntity> list = new List<AparelhoEntity>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Select id,nome,status,cronograma,consumo,id_comodo from tb_casa where id_usuario = @id_comodo";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@id_comodo", id_comodo);
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
                                    list.Add(new AparelhoEntity { id = reader.GetInt32(reader.GetOrdinal("id")), Nome = reader.GetString(reader.GetOrdinal("Nome")), status = reader.GetString(reader.GetOrdinal("status")), Cronograma = reader.GetDateTime(reader.GetOrdinal("cronograma")), id_comodo = id_comodo });
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
    }
}
