using ConsoleApp75.Result;
using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Repositories
{
    public class LogisticService:User
    {
        CarTypeRepository carTypeRepository;
        DirectionRepository directionRepository;
        CrashedRepository crashedRepository;
        ContainerRepository containerRepository;
        CalculationService calculationService;

        public LogisticService(string carType, bool isCrashed, bool isClosed, string from, string to) : base(carType, isCrashed, isClosed, from, to)
        {
        }
       
        //public int GetPrice()
        //{
           
        //}

        
    }

}
