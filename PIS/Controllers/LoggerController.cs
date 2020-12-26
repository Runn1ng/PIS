using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PIS.Models;

namespace PIS.Controllers
{
    class LoggerController
    {
        public static void Log(User user, string action)
        {
            if (!System.IO.File.Exists("Log.txt"))
            {
                System.IO.File.CreateText("Log.txt");
            }

            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt"))
                {
                    sw.WriteLine(user.Id + " " + user.Username + " " + action +
                                 " " + DateTime.Now.ToString());
                }
            }
            catch (Exception e) {Console.WriteLine();}
        }
    }
}
