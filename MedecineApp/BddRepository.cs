using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using MedicamentBO;



namespace MedecineApp
{
    
    public class BddRepository
    {
        private readonly string _connectionString;

        public BddRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BDDConnection"].ConnectionString;
        }

        public IEnumerable<Medicament> BuildBibliothequeMedicaments()
        {
            var medicaments = new List<Medicament>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Medicaments", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medicament = new Medicament(
                            reader.GetInt64("Code_medicament"),
                            reader.GetString("Designation"),
                            reader.GetString("Laboratoire")
                        );
                        medicaments.Add(medicament);
                    }
                }
            }
            return medicaments;
        }
    }
}
