using Pharmacy.IRepositories;
using Pharmacy.Models;
using Pharmacy.Repositories;
using Pharmcy.IRepositories;
using Pharmcy.Models;
using Pharmcy.Repositories;
using System;
using System.IO;

namespace Pharmcy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepo = new UserRepository();
            IMedicineRepository mRepo = new MedicineRepository();

            void SignUp()
            {
                Console.Write("Enter FirstName:  ");
                string fname = Console.ReadLine();

                Console.Write("Enter LastName:  ");
                string lname = Console.ReadLine();

                Console.Write("Enter Login:  ");
                string login = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();


                User user = new User
                {
                    FirstName = fname,
                    LastName = lname,
                    Login = login,
                    Password = password,

                };
                userRepo.Create(user);

            }

            void SignIn()
            {

                Console.Write("Enter Login: ");
                string login = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                Console.Clear();

                User result = userRepo.Login(login, password);

                if (result == null)
                    Console.WriteLine("Bunday foydalanuvchi mavjud emas");

                else
                {
                    AptekaMenu();
                }
            }

            void AddMedicine()
            {
                while (true)
                {
                    Console.Write("Enter medicine name: ");
                    string medcineName = Console.ReadLine();
                    int num;
                    decimal price;
                    try
                    {
                        Console.Write("Enter medicine number: ");
                        price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter medicine soni: ");
                        num = int.Parse(Console.ReadLine());
                        Console.Clear();
                        mRepo.Add(new Medicine { MedicineName = medcineName,  Soni = num , Narxi = price });

                    }
                    catch
                    {
                        Console.WriteLine($"\nFaqat son kiriting!\n");
                    }

                    Console.WriteLine("1-Add medicine  0-back");
                    string input = Console.ReadLine();
                    Console.Clear();

                    if (input == "1") continue;
                    else if (input == "0") break;

                }
            }


            void SearchMedicine()
            {
                while (true)
                {
                    Console.Write("Enter medicine name: ");
                    string medName = Console.ReadLine();
                    string[] files = mRepo.GetAll();
                    Console.Clear();

                    int son = 0;

                    foreach (string file in files)
                    {
                        string medicinePath = Path.GetFileName(file);

                        if (medicinePath == medName + ".txt")
                        {
                            son = 1;
                            string[] medicineDetails = File.ReadAllLines(file);

                            Console.WriteLine("\n|{0,20}|{1,5}|{2,8}|", "Medicine name", "Amount", "Cost");
                            Console.WriteLine("_____________________________________");
                            Console.WriteLine("|{0,20}|{1,5}|{2,8}$|\n", medicineDetails[0], medicineDetails[1], medicineDetails[2]);
                        }
                    }
                    if (son == 0)
                    {
                        Console.WriteLine("There is no such drug.");
                    }

                    Console.WriteLine("1-Search again  0-Back");
                    string input = Console.ReadLine();

                    if (input == "1") continue;

                    else if (input == "0") break;
                }

            }

            void DeleteMedicine()
            {
                while (true)
                {
                    Console.Write("Enter medicine name: ");
                    string medName = Console.ReadLine();
                    Console.Clear();

                    mRepo.Delete(medName);

                    Console.WriteLine("1-Deleted again 0-Back");

                    string input = Console.ReadLine();
                    Console.Clear();

                    if(input == "1") continue;
                    else if(input == "0") break;
                }
        }

            void ListMedicine()
            {
                while (true)
                {
                    Console.WriteLine("|{0,15}|{1,5}|{2,8}|", "Medicine name", "Amount", "Cost");
                    Console.WriteLine("________________________________");
                    string[] files = mRepo.GetAll();
                    foreach (string file in files)
                    {
                        string[] userDetails = File.ReadAllLines(file);
                        Console.WriteLine("|{0,15}|{1,5}|{2,8}$|", userDetails[0], userDetails[1], userDetails[2]);
                    }

                    Console.WriteLine("\n0-Back");
                    string input = Console.ReadLine();
                    Console.Clear();

                    if (input == "0") break;
                }
            }

            bool CheckName(string medName)
            {
                string[] files = mRepo.GetAll();
               

                foreach (string file in files)
                {
                    string medicinePath = Path.GetFileName(file);

                    if (medicinePath == medName + ".txt")
                    {
                        return true;
                    }
                }
                return false;
            }

            void UpdateMedicine()
            {
                while (true)
                {
                     Console.Write("Enter update medicine: ");
                     string  medName = Console.ReadLine();

                    if(CheckName(medName))
                    {
                        int num;
                        decimal price;
                        try
                        {
                            Console.Write("Enter medicine number: ");
                            price = decimal.Parse(Console.ReadLine());

                            Console.Write("Enter medicine soni: ");
                            num = int.Parse(Console.ReadLine());
                            Console.Clear();
                            mRepo.Update(new Medicine { MedicineName = medName, Soni = num, Narxi = price });
                        }
                        catch
                        {
                            Console.WriteLine($"\nEnter only number\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("there is no such drug");
                    }

                    Console.WriteLine("1-Update again 0-Back");

                }
            }


            while (true)
            {

                Console.WriteLine("Welcome toCheap Pharmacy!\n1-Sign Up\n2-Sign In\n0-Back");
                string s = Console.ReadLine();
                Console.Clear();


                if (s == "1")
                {
                    SignUp();
                    Console.Clear();
                }

                else if (s == "2")
                {
                    SignIn();
                    Console.Clear();
                }

                else if (s == "0")
                {
                    Console.WriteLine("Thank you for your service");
                    break;
                }
                else
                {
                    Console.WriteLine("Error");
                    break;
                }
            }


         
           void AptekaMenu()
            {
                while (true)
                {
                    Console.WriteLine("1-List medicine\n2-Add medicine\n3-Search\n4-Delete\n5-Update\n0-Back");
                    string str = Console.ReadLine();
                    Console.Clear();
                    if (str == "1")
                    {
                        ListMedicine();
                    }
                    else if (str == "2")
                        AddMedicine();

                    else if (str == "3")
                    {
                        SearchMedicine();
                    }
                    else if (str == "4")
                        DeleteMedicine();
                    else if (str == "5")
                        UpdateMedicine();
                    else if (str == "0") break;
                }
            }

     
        }
    }
}
