using LogisticService.Services.Models;

namespace LogisticService.Services
{
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
