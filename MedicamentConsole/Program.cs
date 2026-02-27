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
            BddRepository.Open();

            /*Console.WriteLine("Tous les médicaments:");
            foreach (var medicament in biblioteque.AfficherAllMedicament())
            {                
                Console.WriteLine(medicament);
            }*/

            //Console.WriteLine("Tous les Patients:");
            //foreach (var medicament in bibliotheque.AfficherAllPatients())
            //{                
            //    Console.WriteLine(medicament);
            //}

        }
    }
}
