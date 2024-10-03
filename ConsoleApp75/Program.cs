using ConsoleApp75;
using ConsoleApp75.CalculationResult;
using ConsoleApp75.NewFolder1;
using ConsoleApp75.Result;
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
            try
            {
                Hop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception - {0}", e);
            }
        }
        static void Hop()
        {
            CheckStackTrace();
            Hip();
        }
        static void Hip()
        {
            CheckStackTrace();
            Hop();
        }
        static void CheckStackTrace()
        {
            StackTrace s = new StackTrace();
            if (s.FrameCount > 50)
                throw new Exception("Big stack!!!!");
        }
        //    Resuult resuult = new Resuult();
        //    resuult.PrintResult();


    }

       
    }


