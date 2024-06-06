namespace TechHomeApi.Data.Provider
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Database connection string is required! Look at the environment property: DATABASE_CONNECTION_STRING");


            _connectionString = connectionString;

        }

    }
}
