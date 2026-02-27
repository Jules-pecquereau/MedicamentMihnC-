using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentBO
{
    public class ExeptionRecherchePatient : Exception
    {
        public ExeptionRecherchePatient(string message) : base(message)
        {
        }

    }
}
