using MedicamentBO;
using MedecineApp;
using System.Data.SqlClient;

namespace MedicamentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var BddRepository = new BddRepository();
            var biblioteque = BddRepository.BuildBibliothequeMedicaments();

            var bibliothequePatients = BddRepository.BuildBibliothequePatients();
            Console.WriteLine("Tous les médicaments:");
            foreach (var medicament in biblioteque.AfficherAllMedicament())
            {                
                Console.WriteLine(medicament);
            }

            Console.WriteLine("\nRecherche de médicaments contenant 'Paracétamol':");
            try
            {
                var medicamentsTrouves = biblioteque.RechercherMedicament("Paracétamol");
                foreach (var medicament in medicamentsTrouves)
                {
                    Console.WriteLine(medicament);
                }
            }
            catch (ExeptionRechercheMedicament ex)
            {
                Console.WriteLine($"erreur: {ex.Message}");
            }

            Console.WriteLine("\nRecherche de médicaments du laboratoire 'Sanofi':");
            try
            {
                var medicamentsSanofi = biblioteque.RechercherParLaboratoire("Sanofi");
                foreach (var medicament in medicamentsSanofi)
                {
                    Console.WriteLine(medicament);
                }
            }
            catch (ExeptionRechercheMedicament ex)
            {
                Console.WriteLine($"erreur: {ex.Message}");
            }
            



            Console.WriteLine("Tous les Patients:");
            foreach (var patient in bibliothequePatients.AfficherAllPatients())
            {                
                Console.WriteLine(patient);
            }

        }
    }
}
