using LogisticService.Models;
using LogisticService.Models.RequestModels;
using LogisticService.Repositories;
using System;

namespace LogisticService.Menues
{
    public class AdminMenu : Menu
    {
        public override void Start()
        {
            Console.WriteLine("Wich model do you want to choose?");
            Console.WriteLine("1.CarType || 2.Direction || 3.Container || 4.Crashed");

            int choise;

            Console.ReadLine().IsValid(out choise);

            switch (choise)
            {
                case 1:
                    ShowCarTypeAdminMenu(new CarTypeRepository());
                    break;
                case 2:
                    ShowDirectionAdminMenu(new DirectionRepository());
                    break;
                case 3:
                    ShowContainerAdminMenu(new ContainerRepository());
                    break;
                case 4:
                    ShowCrashedAdminMenu(new CrashedRepository());
                    break;
                default:
                    break;
            }
        }

        private void ShowContainerAdminMenu(IRepository<Container, ContainerRequest> containerRepository)
        {
            Console.WriteLine("Wich method do you want to use?");
            Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");

            void PrintDetails(Container container1)
            {
                Console.WriteLine($"Id: {container1.Id} || Coef {container1.Coef} || IsClosed: {container1.IsClosed}");
            }

            Container container = new Container();

            int option;

            Console.ReadLine().IsValid(out option);

            switch (option)
            {
                case 1:
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

                    Console.WriteLine("Choose wich one do you want update?");
                    Console.WriteLine("1.IsClosed || 2.Coef || 3.All ");

                    int n;
                    Console.ReadLine().IsValid(out n);
                    if (n == 2)
                    {
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        container.Coef = coef2;
                    }
                    else if (n == 1)
                    {
                        Console.WriteLine("Input isClosed: ");
                        bool closed = bool.Parse(Console.ReadLine());
                        container.IsClosed = closed;
                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("Input isClosed: ");
                        bool closed = bool.Parse(Console.ReadLine());
                        container.IsClosed = closed;
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        container.Coef = coef2;
                    }

                    containerRepository.Update(container, id2);
                    break;

                case 4:
                    Console.WriteLine("Input id: ");
                    int id3 = int.Parse(Console.ReadLine());
                    var q = containerRepository.GetById(id3);
                    PrintDetails(q);
                    break;

                case 5:
                    containerRepository.GetAll().ForEach(x => PrintDetails(x));

                    break;
            }
        }

        private void ShowDirectionAdminMenu(IRepository<Direction, DirectionRequest> directionRepository)
        {
            Console.WriteLine("Wich method do you want to use?");
            Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");

            void PrintDetails(Direction direction1)
            {
                Console.WriteLine($"Id: {direction1.Id} || To: {direction1.To} || Price: {direction1.Price} || From: {direction1.From} || Distance: {direction1.Distance}");
            }

            Direction direction = new Direction();

            int option;

            Console.ReadLine().IsValid(out option);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Input from: ");
                    string from = Console.ReadLine();
                    direction.From = from;
                    Console.WriteLine("Input to: ");
                    string to = Console.ReadLine();
                    direction.To = to;
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
                    int id2 = int.Parse(Console.ReadLine());// need validation
                    direction.Id = id2;

                    Console.WriteLine("Select which ones you want to modify․ If you don't want modify input 5");

                    while (true)
                    {
                        Console.WriteLine("1.From || 2.To || 3.Price || 4.Distance || 5.Exit");

                        int n;
                        Console.ReadLine().IsValid(out n);

                        if (n > 5 || n < 0)
                        {
                            Console.WriteLine("Invalid input. Try again");

                            continue;
                        }
                        else if (n == 5)
                        {
                            break;
                        }

                        switch (n)
                        {
                            case 1:
                                Console.WriteLine("Input from: ");
                                string from2 = Console.ReadLine();
                                direction.From = from2;
                                break;
                            case 2:

                                Console.WriteLine("Input to: ");
                                string to2 = Console.ReadLine();
                                direction.To = to2;
                                break;
                            case 3:
                                Console.WriteLine("Input price: ");
                                decimal price2 = decimal.Parse(Console.ReadLine());
                                direction.Price = price2;
                                break;
                            case 4:
                                Console.WriteLine("Input distance: ");
                                float distance2 = float.Parse(Console.ReadLine());
                                direction.Distance = distance2;
                                break;
                        }
                    }

                    directionRepository.Update(direction, id2);
                    break;

                case 4:
                    Console.WriteLine("Input id: ");

                    int id3 = int.Parse(Console.ReadLine());// error
                    var dir = directionRepository.GetById(id3);

                    PrintDetails(dir);

                    break;

                case 5:
                    directionRepository
                        .GetAll()
                        .ForEach(x => PrintDetails(x));

                    break;
            }
        }

        private void ShowCarTypeAdminMenu(IRepository<CarType, CarTypeRequest> carTypeRepository)
        {
            Console.WriteLine("Wich method do you want to use?");
            Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");

            void PrintDetails(CarType carType1)
            {
                Console.WriteLine($"Id: {carType1.Id} || Model: {carType1.Model} ||Coef: {carType1.Coef}");
            }

            CarType carType = new CarType();

            int option;

            Console.ReadLine().IsValid(out option);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Input model: ");
                    string model = Console.ReadLine();
                    carType.Model = model;
                    Console.WriteLine("Input coef: ");
                    float coef = float.Parse(Console.ReadLine());
                    carType.Coef = coef;
                    carTypeRepository.Add(carType);
                    break;

                case 2:
                    Console.WriteLine("Input id: ");
                    int id1 = int.Parse(Console.ReadLine());
                    carTypeRepository.Delete(id1);
                    break;

                case 3:
                    Console.WriteLine("Input id: ");
                    int id2 = int.Parse(Console.ReadLine());
                    carType.Id = id2;

                    Console.WriteLine("Choose wich one do you want update?");
                    Console.WriteLine("1.Model || 2.Coef || 3.All ");

                    int n;
                    Console.ReadLine().IsValid(out n);
                    if (n == 1)
                    {
                        Console.WriteLine("Input model: ");
                        string model2 = Console.ReadLine();
                        carType.Model = model2;
                    }
                    else if (n == 2)
                    {
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        carType.Coef = coef2;
                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("Input model: ");
                        string model2 = Console.ReadLine();
                        carType.Model = model2;
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        carType.Coef = coef2;
                    }
                    carTypeRepository.Update(carType, id2);
                    break;

                case 4:
                    Console.WriteLine("Input id: ");
                    int id3 = int.Parse(Console.ReadLine());
                    var s = carTypeRepository.GetById(id3);
                    PrintDetails(s);
                    break;

                case 5:
                    carTypeRepository.GetAll().ForEach(details => PrintDetails(details));

                    break;
            }
        }

        private void ShowCrashedAdminMenu(IRepository<Crashed, CrashedRequest> crashedRepository)
        {
            Console.WriteLine("Wich method do you want to use?");
            Console.WriteLine("1.Add || 2.Delete || 3.Update || 4.GetById || 5.GetAll");

            void PrintDetails(Crashed crashed1)
            {
                Console.WriteLine($"Id: {crashed1.Id} || Coef {crashed1.Coef} || IsCrashed: {crashed1.IsCrashed}");
            }

            int option;

            Console.ReadLine().IsValid(out option);

            Crashed crashed = new Crashed();

            switch (option)
            {
                case 1:
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

                    Console.WriteLine("Choose wich one do you want update?");
                    Console.WriteLine("1.IsCrashed || 2.Coef || 3.All ");

                    int n;
                    Console.ReadLine().IsValid(out n);

                    if (n == 1)
                    {
                        Console.WriteLine("Input isCrashed: ");
                        bool isCrashed1 = bool.Parse(Console.ReadLine());
                        crashed.IsCrashed = isCrashed1;
                    }
                    else if (n == 2)
                    {
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        crashed.Coef = coef2;
                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("Input isCrashed: ");
                        bool isCrashed1 = bool.Parse(Console.ReadLine());
                        crashed.IsCrashed = isCrashed1;
                        Console.WriteLine("Input coef: ");
                        float coef2 = float.Parse(Console.ReadLine());
                        crashed.Coef = coef2;
                    }
                    crashedRepository.Update(crashed, id2);
                    break;

                case 4:
                    Console.WriteLine("Input id: ");
                    int id3 = int.Parse(Console.ReadLine());
                    var x = crashedRepository.GetById(id3);
                    PrintDetails(x);

                    break;

                case 5:
                    crashedRepository.GetAll().ForEach(x1 => PrintDetails(x1));

                    break;
            }

        }
    }

    static class StringExtentions
    {
        public static bool IsValid(this string input, out int num)
        {
            int choise;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Incorect option");
                num = -1;
                return false;
            }

            if (int.TryParse(input, out choise))
            {
                num = choise;
                return true;
            }
            Console.WriteLine("Incorect option");

            num = -1;
            return false;
        }
    }
}
