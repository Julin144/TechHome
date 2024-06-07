using System.Collections.Generic;
using System.Data.SqlClient;
using TechHomeApi.Model.Entity;

namespace TechHomeApi.Data.Repository
{
    public class UsuarioRepository
    {

        string _connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        public int Login(string login,string password)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Select id from tb_usuario where login = @login and password = @password";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
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
                                     id = reader.GetInt32(reader.GetOrdinal("id"));
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
            return 0;
        }
    }
    
}
