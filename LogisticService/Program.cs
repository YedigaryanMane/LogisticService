using LogisticService;
using LogisticService.Result;
using LogisticService.Menues;
using LogisticService.Repositories;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Good day, we are glad to see you on our page");
            Menu menu = null;

            while (true)
            {
                Console.WriteLine("Dear visitor choose, wich one do you want?");
                Console.WriteLine("1.Admin || 2.User || 0.Exist");

                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 0:
                        break;
                        case 1:
                        menu = new AdminMenu();
                        break;
                        case 2:
                        menu = new UserMenu();
                        break;
                    default:
                        Console.WriteLine("Option is incorrect.");
                        break;
                }
                menu.Start();
            }

        }
    }
}
