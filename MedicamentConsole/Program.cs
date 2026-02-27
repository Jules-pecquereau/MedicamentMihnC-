using MedicamentBO;
namespace MedicamentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
            }

            Console.WriteLine("Tous les médicaments:");
            foreach (var medicament in biblioteque.AfficherAllMedicament())
            {                
                Console.WriteLine(medicament);
            }

        }
    }
}
