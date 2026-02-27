using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentBO
{
    internal class Utilisateur : User
    {
        public string MotDePasse { get; }
        public string specialite { get; }
        public bool IsAdmin { get; }
        public bool IsActif { get; }

        public Utilisateur(string nom, string prenom, string email, string motDePasse, string specialite, bool isAdmin, bool isActif): base(nom, prenom, email)
        {
            MotDePasse = motDePasse;
            this.specialite = specialite;
            IsAdmin = isAdmin;
            IsActif = isActif;
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom} - {Email} - {specialite} - {(IsAdmin ? "Admin" : "User")} - {(IsActif ? "Actif" : "Inactif")}";
        }
    }
}
