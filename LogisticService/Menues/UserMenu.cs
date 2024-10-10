using LogisticService.Models;
using LogisticService.Models.RequestModels;
using LogisticService.Repositories;
using LogisticService.Services;
using LogisticService.Services.Models;
using System;

namespace LogisticService.Menues
{
    public class UserMenu : Menu
    {
        public CarTypeRequest GetingCarType()
        {
            Console.WriteLine("Write car type: ");

            string type = Console.ReadLine();

            CarTypeRequest carTypeRequest = new CarTypeRequest(type);

            return carTypeRequest;
        }

        public ContainerRequest GetingContainer()
        {
            Console.WriteLine("How do you want to open or close container?");

            bool isClosed = bool.Parse(Console.ReadLine());

            ContainerRequest containerRequest = new ContainerRequest(isClosed);

            return containerRequest;
        }

        public CrashedRequest GetingCrashed()
        {
            Console.WriteLine("Is your car crashed?");

            bool isCrashed = bool.Parse(Console.ReadLine());

            CrashedRequest crashedRequest = new CrashedRequest(isCrashed);

            return crashedRequest;
        }

        public DirectionRequest GetingDirection()
        {
            Console.WriteLine("From where do you want to bring your car?");

            string from = Console.ReadLine();

            Console.WriteLine("Where do you want take the car?");

            string to = Console.ReadLine();

            DirectionRequest directionRequest = new DirectionRequest(from, to);

            return directionRequest;
        }

        public override void Start()
        {
            CarTypeRequest carTypeRequest = GetingCarType();
            CrashedRequest crashedRequest = GetingCrashed();
            ContainerRequest containerRequest = GetingContainer();
            DirectionRequest dirRequest = GetingDirection();

            ICalculationService calculationService = new CalculationService();
            IRepository<CarType, CarTypeRequest> repository = new CarTypeRepository();
            IRepository<Direction, DirectionRequest> repository1 = new DirectionRepository();
            IRepository<Crashed, CrashedRequest> repository2 = new CrashedRepository();
            IRepository<Container, ContainerRequest> repository3 = new ContainerRepository();

            CarType carType = repository.Find(carTypeRequest);
            Direction direction = repository1.Find(dirRequest);
            Container container = repository3.Find(containerRequest);
            Crashed crashed = repository2.Find(crashedRequest);

            float result = calculationService.Calculate(new CalculationModel(carType, direction, container, crashed));

            if (result > 0)
            {
                Console.WriteLine($"Result:{result}");
            }
            else
            {
                Console.WriteLine("Data does not satisfy");
            }
        }
    }
}
