using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmcy.Service
{
    public class MethodService
    {
        public static string GetUserPath(Guid Id)
        {
            return Path.Combine(Constants.UserDbPath, Id.ToString() + ".txt");
        }
        public static string GetMedicinePath(string medicineName)
        {
            return Path.Combine(ConstantsMedicine.UserDbPath, medicineName.ToString() + ".txt");
        }
    }
}
