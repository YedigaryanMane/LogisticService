using ConsoleApp75.CalculationResult;
using ConsoleApp75.Models;
using ConsoleApp75.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.NewFolder1
{
  
    public class AdminHelper
    {
       public int Count {  get; set; }
        public void AdminWork()
        {
            while (true)
            {
                Console.WriteLine("Wich model do you want to choose?");
                Console.WriteLine("1.CarType || 2.Direction || 3.Container || 4.Crashed");                               
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
                        Console.WriteLine("Wich method do you want to use?");
                        Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");
                        CarTypeRepository carTypeRepository = new CarTypeRepository();
                        CarType carType = new CarType();
                        n = int.Parse(Console.ReadLine());                       

                        switch (n)
                        {
                            case 1:
                                Console.WriteLine("Input id: ");
                                int id = int.Parse(Console.ReadLine());
                                carType.Id = id;
                                Console.WriteLine("Input model: ");
                                string model = Console.ReadLine();
                                carType.Model = model;
                                Console.WriteLine("Input price: ");
                                decimal price = decimal.Parse(Console.ReadLine());
                                carType.Price = price;
                                Console.WriteLine("Input coef: ");
                                float coef = float.Parse(Console.ReadLine());
                                carType.Coef = coef;
                                carTypeRepository.Add(carType);
                                break;

                                case 2:
                                Console.WriteLine("Input id: ");
                                int id1 = int.Parse (Console.ReadLine());
                                carTypeRepository.Delete(id1);
                                break;

                                case 3:
                                Console.WriteLine("Input id: ");
                                int id2 = int.Parse(Console.ReadLine());
                                carType.Id = id2;
                                Console.WriteLine("Input model: ");
                                string model2 = Console.ReadLine();
                                carType.Model = model2;
                                Console.WriteLine("Input price: ");
                                decimal price2 = decimal.Parse(Console.ReadLine());
                                carType.Price = price2;
                                Console.WriteLine("Input coef: ");
                                float coef2 = float.Parse(Console.ReadLine());
                                carType.Coef = coef2;
                                carTypeRepository.Update(carType);
                                break;

                                case 4:
                                Console.WriteLine("Input id: ");
                                int id3 = int.Parse (Console.ReadLine());
                                carTypeRepository.GetById(id3);
                                Console.WriteLine($"Id: {carType.Id} || Model: {carType.Model} || Price: {carType.Price} || Coef: {carType.Coef}");
                                break;

                                case 5:
                                List<CarType> list = carTypeRepository.GetAll();

                                foreach (var item in list) 
                                {
                                    Console.WriteLine($"Id: {carType.Id} || Model: {carType.Model} || Price: {carType.Price} || Coef: {carType.Coef}");
                                }
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Wich method do you want to use?");
                        Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");
                        DirectionRepository directionRepository = new DirectionRepository();
                        Direction direction = new Direction();
                        n = int.Parse(Console.ReadLine());

                        switch (n)
                        {
                            case 1:
                                Console.WriteLine("Input id: ");
                                int id = int.Parse(Console.ReadLine());
                                direction.Id = id;
                                Console.WriteLine("Input to: ");
                                string to = Console.ReadLine();
                                direction.To = to;
                                Console.WriteLine("Input from: ");
                                string from = Console.ReadLine();
                                direction.From = from;
                                Console.WriteLine("Input price: ");
                                decimal price = decimal.Parse(Console.ReadLine());
                                direction.Price = price;
                                Console.WriteLine("Input distance: ");
                                float distance = float.Parse(Console.ReadLine());
                                direction.Distance = distance;
                                directionRepository.Add(direction);
                                break;

                            case 2:
                                Console.WriteLine("Input id: ");
                                int id1 = int.Parse(Console.ReadLine());
                                directionRepository.Delete(id1);
                                break;

                            case 3:
                                Console.WriteLine("Input id: ");
                                int id2 = int.Parse(Console.ReadLine());
                                direction.Id = id2;
                                Console.WriteLine("Input to: ");
                                string to2 = Console.ReadLine();
                                direction.To = to2;
                                Console.WriteLine("Input from: ");
                                string from2 = Console.ReadLine();
                                direction.From = from2;
                                Console.WriteLine("Input price: ");
                                decimal price2 = decimal.Parse(Console.ReadLine());
                                direction.Price = price2;
                                Console.WriteLine("Input distance: ");
                                float distance2 = float.Parse(Console.ReadLine());
                                direction.Distance = distance2;
                                directionRepository.Update(direction);
                                break;

                            case 4:
                                Console.WriteLine("Input id: ");
                                int id3 = int.Parse(Console.ReadLine());
                                directionRepository.GetById(id3);
                                Console.WriteLine($"Id: {direction.Id} || To {direction.To} || Price: {direction.Price} || From: {direction.From} || Distance: {direction.Distance}");
                                break;

                            case 5:
                                List<Direction> list = directionRepository.GetAll();

                                foreach (var item in list)
                                {
                                    Console.WriteLine($"Id: {direction.Id} || To {direction.To} || Price: {direction.Price} || From: {direction.From} || Distance: {direction.Distance}");
                                }
                                break;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Wich method do you want to use?");
                        Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");
                        n = int.Parse(Console.ReadLine());
                        CrashedRepository crashedRepository = new CrashedRepository();
                        Crashed crashed = new Crashed();

                        switch (n)
                        {
                            case 1:
                                Console.WriteLine("Input id: ");
                                int id = int.Parse(Console.ReadLine());
                                crashed.Id = id;
                                Console.WriteLine("Input coef: ");
                                float coef = float.Parse(Console.ReadLine());
                                crashed.Coef = coef;
                                Console.WriteLine("Input IsCrashed: ");
                                bool isCrashed = bool.Parse(Console.ReadLine());
                                crashed.IsCrashed = isCrashed;
                                crashedRepository.Add(crashed);
                                break;

                            case 2:
                                Console.WriteLine("Input id: ");
                                int id1 = int.Parse(Console.ReadLine());
                                crashedRepository.Delete(id1);
                                break;

                            case 3:
                                Console.WriteLine("Input id: ");
                                int id2 = int.Parse(Console.ReadLine());
                                crashed.Id = id2;
                                Console.WriteLine("Input coef: ");
                                float coef2 = float.Parse(Console.ReadLine());
                                crashed.Coef = coef2;
                                Console.WriteLine("Input isCrashed: ");
                                bool isCrashed1 = bool.Parse(Console.ReadLine());
                                crashed.IsCrashed = isCrashed1;
                                break;

                            case 4:
                                Console.WriteLine("Input id: ");
                                int id3 = int.Parse(Console.ReadLine());
                                crashedRepository.GetById(id3);
                                Console.WriteLine($"Id: {crashed.Id} || Coef {crashed.Coef} || IsCrashed: {crashed.IsCrashed}");
                                break;

                            case 5:
                                List<Crashed> list = crashedRepository.GetAll();

                                foreach (var item in list)
                                {
                                    Console.WriteLine($"Id: {crashed.Id} || Coef {crashed.Coef} || IsCrashed: {crashed.IsCrashed}");
                                }
                                break;
                        }
                      break;

                    case 4:
                        Console.WriteLine("Wich method do you want to use?");
                        Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");
                        ContainerRepository containerRepository = new ContainerRepository();
                        Container container = new Container();
                        n = int.Parse(Console.ReadLine());

                        switch (n)
                        {
                            case 1:
                                Console.WriteLine("Input id: ");
                                int id = int.Parse(Console.ReadLine());
                                container.Id = id;
                                Console.WriteLine("Input coef: ");
                                float coef = float.Parse(Console.ReadLine());
                                container.Coef = coef;
                                Console.WriteLine("Input isClosed: ");
                                bool isClosed = bool.Parse(Console.ReadLine());
                                container.IsClosed = isClosed;
                                containerRepository.Add(container);
                                break;

                            case 2:
                                Console.WriteLine("Input id: ");
                                int id1 = int.Parse(Console.ReadLine());
                                containerRepository.Delete(id1);
                                break;

                            case 3:
                                Console.WriteLine("Input id: ");
                                int id2 = int.Parse(Console.ReadLine());
                                container.Id = id2;
                                Console.WriteLine("Input coef: ");
                                float coef2 = float.Parse(Console.ReadLine());
                                container.Coef = coef2;
                                Console.WriteLine("Input isClosed: ");
                                bool closed = bool.Parse(Console.ReadLine());
                                container.IsClosed = closed;
                                containerRepository.Update(container);
                                break;

                            case 4:
                                Console.WriteLine("Input id: ");
                                int id3 = int.Parse(Console.ReadLine());
                                containerRepository.GetById(id3);
                                Console.WriteLine($"Id: {container.Id} || Coef {container.Coef} || IsClosed: {container.IsClosed}");
                                break;

                            case 5:
                                List<Container> list = containerRepository.GetAll();

                                foreach (var item in list)
                                {
                                    Console.WriteLine($"Id: {container.Id} || Coef {container.Coef} || IsClosed: {container.IsClosed}");
                                }
                                break;
                        }
                        Count++;
                        Calculate calculate = new Calculate();
                        calculate.CalculateResult();
                        break;

                }
            }
           
        }
    }
}
