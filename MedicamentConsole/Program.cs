using MedicamentBO;
namespace MedicamentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tous les médicaments:");
            foreach (var medicament in biblioteque.AfficherAllMedicament())
            {                
                Console.WriteLine(medicament);
            }

        }
    }
}
