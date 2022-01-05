using Pharmcy.IRepositories;
using Pharmcy.Models;
using Pharmcy.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmcy.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            string fileName = MethodService.GetUserPath(user.Id);
            string userData = user.ToString();
            File.WriteAllText(fileName, userData);
            
            return user;
        }

        public void Delete(string name)
        {
            
        }

        public User Login(string login, string password)
        {
            string[] files = Directory.GetFiles(Constants.UserDbPath);

            foreach (string file in files)
            {
                string[] userDetails = File.ReadAllLines(file);
                string userLogin = userDetails[3];
                string userPassword = userDetails[4];

                if (login == userLogin && password == userPassword)
                {
                    return new User
                    {
                        Id = Guid.Parse(userDetails[0]),
                        FirstName = userDetails[1],
                        LastName = userDetails[2],
                        Login = userDetails[3],
                        Password = userDetails[4]
                    };
                }
                
            }
            
            return null;
        }
    }
}
