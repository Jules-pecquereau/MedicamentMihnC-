using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration; 



namespace MedecineApp
{
    
    public class BddRepository
    {
        private readonly string _connectionString;

        public BddRepository(object cs)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BDDConnection"].ConnectionString;
        }

        public void Open()
        {
            var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
            }
        }
    }
}
