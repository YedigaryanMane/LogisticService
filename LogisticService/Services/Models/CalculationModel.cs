using LogisticService.Models;

namespace LogisticService.Services.Models
{
    public class CalculationModel
    {
        public CalculationModel(CarType carType, Direction direction, Container container, Crashed crashed)
        {
            CarType = carType;
            Direction = direction;
            Container = container;
            Crashed = crashed;
        }

        public CarType CarType { get; set; }
        public Direction Direction { get; set; }
        public Container Container { get; set; }
        public Crashed Crashed { get; set; }
    }
}
