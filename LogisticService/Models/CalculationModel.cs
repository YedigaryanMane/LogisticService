using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Models
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
