using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentBO
{
    internal class Ordonnance
    {

        public string Designation { get; }
        public string Posologie { get; }

        public DateTime Date { get; }
        public int NumeroPatient { get; }

        public IEnumerable<Medicament> Medicaments => medicamentslist.AsReadOnly();

        private List<Medicament> medicamentslist = new List<Medicament>();




        public Ordonnance(string designation, string posologie, Medicament medicament, DateTime date, int numeroPatient)
        {
            Designation = designation;
            Posologie = posologie;
            Date = date;
            NumeroPatient = numeroPatient;

            if (medicament != null)
            {
                medicamentslist.Add(medicament);
            }

        }

        public override string ToString()
        {
            return $"Ordonnance: {Designation}, Posologie: {Posologie}, Code Médicament: {medicamentslist}, Date: {Date.ToShortDateString()}, Numéro Patient: {NumeroPatient}";
        }


    }
}
