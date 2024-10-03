using ConsoleApp75.Models;
using ConsoleApp75.Repositories;
using System;
using System.Collections.Generic;
using ConsoleApp75.Result;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;

namespace ConsoleApp75.User
{
   
    public class UserHelper
    {
        Resuult resuult = new Resuult();
        public int Count {  get; set; }
        public void UserWork()
        {
            while (true)
            {

                Console.WriteLine("Wich method do you want to use?");
                Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");
                PersonRepository personRepository = new PersonRepository();
                Person person = new Person();
                int n;
                string optionStr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(optionStr))
                {
                    Console.WriteLine("Incorect option");
                    continue;
                }

                if (!int.TryParse(optionStr, out n))
                {
                    Console.WriteLine("Incorect option");
                    continue;
                }

                if (n == 0)
                {
                    Console.WriteLine("You go out");
                    break;
                }

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Input id: ");
                        int id = int.Parse(Console.ReadLine());
                        person.Id = id;
                        Console.WriteLine("Input emaill: ");
                        string email = Console.ReadLine();
                        person.Email = email;
                        Console.WriteLine("Input PhoneNumber: ");
                        string phoneNumber = Console.ReadLine();
                        person.PhoneNumber = phoneNumber;
                        Console.WriteLine("Input leadTime: ");
                        string leadTime = Console.ReadLine();
                        person.ԼeadTime = leadTime;
                        personRepository.Add(person);
                        Count++;
                        resuult.PrintResult();
                        break;

                    case 2:
                        Console.WriteLine("Input id: ");
                        int id1 = int.Parse(Console.ReadLine());
                        personRepository.Delete(id1);
                        break;

                    case 3:
                        Console.WriteLine("Input id: ");
                        int id2 = int.Parse(Console.ReadLine());
                        person.Id = id2;
                        Console.WriteLine("Input emaill: ");
                        string email2 = Console.ReadLine();
                        person.Email = email2;
                        Console.WriteLine("Input PhoneNumber: ");
                        string phoneNumber2 = Console.ReadLine();
                        person.PhoneNumber = phoneNumber2;
                        Console.WriteLine("Input leadTime: ");
                        string leadTime2 = Console.ReadLine();
                        person.ԼeadTime = leadTime2;
                        personRepository.Update(person);
                        break;

                    case 4:
                        Console.WriteLine("Input id: ");
                        int id3 = int.Parse(Console.ReadLine());
                        personRepository.GetById(id3);
                        Console.WriteLine($"Id: {person.Id} || Email: {person.Email} || LeadTime: {person.ԼeadTime} || PhoneNumber: {person.PhoneNumber}");
                        break;

                    case 5:
                        List<Person> list = personRepository.GetAll();

                        foreach (var item in list)
                        {
                            Console.WriteLine($"Id: {person.Id} || Email: {person.Email} || LeadTime: {person.ԼeadTime} || PhoneNumber: {person.PhoneNumber}");
                        }
                        break;
                }
            }
        }
    }
}
