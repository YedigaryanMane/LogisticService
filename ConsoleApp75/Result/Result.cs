using ConsoleApp75.CalculationResult;
using ConsoleApp75.NewFolder1;
using ConsoleApp75.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Result
{
   public class Resuult {
        public void PrintResult()
        {
            Console.WriteLine("Input user data: ");
           

            while (true)
            {
                UserHelper userHelper = new UserHelper();

                userHelper.UserWork();
               
            }
        }

        public void PrintResult2()
        {
            while (true)
            {
                int m = 1;
                UserHelper userHelper = new UserHelper();

                if (userHelper.Count == m)
                {
                    
                    AdminHelper adminHelpeer = new AdminHelper();
                    adminHelpeer.AdminWork();
                   
                    break;
                }
               
            }
        }
    }
}
