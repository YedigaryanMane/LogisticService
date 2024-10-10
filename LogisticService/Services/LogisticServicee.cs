using LogisticService.Models;
using LogisticService.Models.RequestModels;
using LogisticService.Repositories;
using LogisticService.Services.Models;

namespace LogisticService.Services
{
    public class LogisticServicee : ILogisticSerivce
    {
        private readonly IRepository<CarType, CarTypeRequest> _carTypeRepository;
        private readonly IRepository<Direction, DirectionRequest> _directionRepository;
        private readonly IRepository<Crashed, CrashedRequest> _crashedRepository;
        private readonly IRepository<Container, ContainerRequest> _containerRepository;
        private readonly ICalculationService _calculationService;

        public LogisticServicee(IRepository<CarType, CarTypeRequest> carTypeRepository,
            IRepository<Direction, DirectionRequest> directionRepository,
            IRepository<Crashed, CrashedRequest> crashedRepository,
            IRepository<Container, ContainerRequest> containerRepository,
            ICalculationService calculationService)
        {
            _carTypeRepository = carTypeRepository;
            _directionRepository = directionRepository;
            _crashedRepository = crashedRepository;
            _containerRepository = containerRepository;
            _calculationService = calculationService;
        }

        public LogisticServicee() { }

        public float GetPrice(LogisticModel logisticModel)
        {
            var carType = _carTypeRepository.Find(new CarTypeRequest(logisticModel.CarType));
            var direction = _directionRepository.Find(new DirectionRequest(logisticModel.From, logisticModel.To));
            var crashed = _crashedRepository.Find(new CrashedRequest(logisticModel.IsCrushed));
            var container = _containerRepository.Find(new ContainerRequest(logisticModel.IsClosed));

            return _calculationService.Calculate(new CalculationModel(carType, direction, container, crashed));
        }
    }
}
