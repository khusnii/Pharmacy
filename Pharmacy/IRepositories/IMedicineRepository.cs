using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.IRepositories
{
    public interface IMedicineRepository
    {
        
        Medicine Add(Medicine medicine);
        string[] GetAll();
        void Delete(string medicine);

        void Update(Medicine medicine);

       
    }
}
