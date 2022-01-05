using Pharmcy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmcy.IRepositories
{
    public interface IUserRepository

    {
        User Create(User user);
        User Login(string login, string password);

        void Delete(string name);
    }
}
