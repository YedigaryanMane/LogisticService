using LogisticService.Result;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Models.RequestModels;

namespace LogisticService.Repositories
{
    public interface ILogisticSerivce
    {
        float GetPrice(LogisticModel logisticModel);
    }

    public class LogisticModel
    {
        public LogisticModel(string from, string to, bool isClosed, bool isCrushed, string carType)
        {
            From = from;
            To = to;
            IsClosed = isClosed;
            IsCrushed = isCrushed;
            CarType = carType;
        }

        public string From { get; set; }
        public string To { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCrushed { get; set; }
        public string CarType { get; set; }
    }

   
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
