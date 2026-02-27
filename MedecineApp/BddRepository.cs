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

        public BibliotequeMedicament BuildBibliothequeMedicaments()
        {
            var bibliotheque = new BibliotequeMedicament("Ma Bibliothèque de Médicaments");

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM medicament", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medicament = new Medicament(
                            reader.GetInt64("Code_medicament"),
                            reader.GetString("Designation"),
                            reader.GetString("Laboratoire")
                        );
                        bibliotheque.AjouterMedicament(medicament);
                    }
                }
            }
            return bibliotheque;
        }
        public BibliothequePatient BuildBibliothequePatients()
        {
            var bibliotheque = new BibliothequePatient();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM patient", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var patient = new Patient(
                            reader.GetInt32("Numero_patient"),
                            reader.GetString("nom"),
                            reader.GetString("prenom"),
                            reader.GetString("adresse_mail"),
                            reader.GetString("adresse"),
                            reader.GetString("code_postal"),
                            reader.GetString("ville"),
                            reader.GetString("pays"),
                            reader.GetInt64("numero_de_securite"),
                            reader.GetInt32("telephone")
                        );
                        bibliotheque.AjouterPatient(patient);
                    }
                }
            }
            return bibliotheque;
        }
    }
}
