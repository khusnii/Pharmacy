using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Medicine
    {
        public string MedicineName { get; set; }
        public int Soni { get; set; }
        public decimal Narxi { get; set; }

        public override string ToString()
        {
            return $"{MedicineName}\n{Soni}\n{Narxi}";
        }
    }
}
