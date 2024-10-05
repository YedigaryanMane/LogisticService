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
           
            
            while (true)
            {
                Menu menu = null;

                Console.WriteLine("1. Admin | 2. User | 0. Exit");

                int option = int.Parse(Console.ReadLine());

                if (option == 0)
                {
                    break;
                }

                switch (option)
                {

                    case 1:
                        menu = new AdminMenu();
                        break;
                    case 2:
                        menu = new UserMenu();
                        break;
                    default:
                        Console.WriteLine("Incorect option. Try again.");
                        break;
                }

                menu.Start();
            }
        }
    }
}
