using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentBO
{
    internal class Patient : User
    {
        public string Adresse { get; }
        public string CodePostal { get; }
        public string Ville { get; }
        public string Pays{ get; }
        public int NumeroSecu { get; }
        public int Telehone { get; }

        public Patient(string nom, string prenom, string email, string adresse, string codePostal, string ville, string pays, int numeroSecu, int telehone) : base(nom, prenom, email)
        {
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            NumeroSecu = numeroSecu;
            Telehone = telehone;
        }

        public override string ToString()
            {
                return $"{Prenom} {Nom} - {Email} - {Adresse}, {CodePostal} {Ville}, {Pays} - N° Sécu: {NumeroSecu} - Téléphone: {Telehone}";
        }

    }
}
