using ConsoleApp75;
using ConsoleApp75.CalculationResult;
using ConsoleApp75.Manues;
using ConsoleApp75.Manues;
using ConsoleApp75.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Manu manu = null;

                Console.WriteLine("1. Admin | 2. User | 0. Exit");

                int option = int.Parse(Console.ReadLine());

                if (option == 0)
                {
                    break;
                }

                switch (option)
                {

                    case 1:
                        manu = new AdminManu();
                        break;
                    case 2:
                        manu = new UserManu();
                        break;
                    default:
                        Console.WriteLine("Incorect option. Try again.");
                        break;
                }

                manu.Start();
            }
        }
    }
}
