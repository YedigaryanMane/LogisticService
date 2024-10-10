using LogisticService.Menues;
using System;

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

                int option;

                Console.ReadLine().IsValid(out option);

                if (option == 0)
                {
                    break;
                }
                else if (option == 1)
                {
                    menu = new AdminMenu();
                }
                else if (option == 2)
                {
                    menu = new UserMenu();
                }
                else
                {
                    Console.WriteLine("Option is incorrect.");
                    continue;
                }

                menu.Start();
            }
        }
    }
}
