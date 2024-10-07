using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Result
{
    public interface ICalculationService
    {
        float Calculate(CalculationModel calculationModel);
    }

    public class CalculationService : ICalculationService
    {
        public float Calculate(CalculationModel calculationModel)
        {
            if (calculationModel.Direction.Price != 0)
            {
                return (float)calculationModel.Direction.Price * calculationModel.Container.Coef * calculationModel.CarType.Coef * calculationModel.Crashed.Coef;
            }
            else
            {
                return (float)calculationModel.Direction.Distance * 100 * calculationModel.Container.Coef * calculationModel.CarType.Coef * calculationModel.Crashed.Coef;
            }
        }
    }
}
