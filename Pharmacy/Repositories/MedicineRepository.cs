using Pharmacy.IRepositories;
using Pharmacy.Models;
using Pharmcy.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {

        public Medicine Add(Medicine medicine)
        {
            string fileName = MethodService.GetMedicinePath(medicine.MedicineName);
            string medicineData = medicine.ToString();
            File.WriteAllText(fileName, medicineData);

            return medicine;
        }

        public void Delete(string medicine)
        {

           string[] files = Directory.GetFiles(ConstantsMedicine.UserDbPath);
           int son = 0;

            foreach (var file in files)
            {
                string medPath = Path.GetFileName(file);

                if (medPath == medicine + ".txt")
                {
                    son = 1;
                    File.Delete(file);

                    Console.WriteLine("This medicine deleted.\n");
                }
            }
            if(son == 0)
            {
                Console.WriteLine("There is no such drug.\n");
            }
        }

        public string[] GetAll()
        {
            return  Directory.GetFiles(ConstantsMedicine.UserDbPath);
        }

       
        

        public void Update(Medicine medicine)
        {
            string[] files = Directory.GetFiles(ConstantsMedicine.UserDbPath);

            foreach (var file in files)
            {
                string medPath = Path.GetFileName(file);

                if (medPath == medicine.MedicineName + ".txt")
                {
                    File.WriteAllText(file, medicine.ToString());
                    
                }
            }
        }
    }
}
