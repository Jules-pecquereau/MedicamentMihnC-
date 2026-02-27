using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentBO
{
    public class BibliothequePatient
    {
        public string Nom { get; set; }
        public IEnumerable<Patient> Patients => lePatients;
        private List<Patient> lePatients = new List<Patient>();

        public IEnumerable<Patient> AfficherAllPatients()
        {
            HashSet<Patient> seen = new HashSet<Patient>();
            foreach (var patient in lePatients)
            {
                seen.Add(patient);
            }
            return seen;
        }

        public void AjouterPatient(Patient patient)
        {
 
                lePatients.Add(patient);

        }

        public IEnumerable<Patient> RechercherPatient(string nom)
        {
            if (!lePatients.Any(p => p.Nom.Contains(nom, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ExeptionRecherchePatient($"Aucun patient trouvé avec le nom '{nom}'.");
            }

            return lePatients.Where(p => p.Nom.Contains(nom, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Patient> RechercherParVille(string ville)
        {
            if (!lePatients.Any(p => p.Ville.Contains(ville, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ExeptionRecherchePatient($"Aucun patient trouvé dans la ville '{ville}'.");
            }

            return lePatients.Where(p => p.Ville.Contains(ville, StringComparison.OrdinalIgnoreCase));
        }

        


    }
}
