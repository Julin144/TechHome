using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Response;
namespace TechHomeApi.Data.Repository
{
    public class CasaRepository
    {
        string _connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

        public List<CasaEntity> GetCasa(int id_usuario)
        {
            List<CasaEntity> list = new List<CasaEntity>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Select id,nome from tb_casa where id_usuario = @idUsuario";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", id_usuario);
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
                                    list.Add(new CasaEntity { id = reader.GetInt32(reader.GetOrdinal("id")), name = reader.GetString(reader.GetOrdinal("Nome"))});
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
        public bool CreateCasa(CasaEntity casa)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "insert into tb_casa(nome,id_usuario) values(@nome,@id_usuario)";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@id_usuario", casa.id_usuario);
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

        public bool UpdateCasa(int id,string name)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "Update tb_casa set nome = @nome where id = @id";

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

        public bool DeleteCasa(int id)
        {
            bool sucess = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();
                    string queryString = "delete from tb_casa where id = @id";

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
