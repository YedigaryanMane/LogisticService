using LogisticService.Services.Models;

namespace LogisticService.Services
{
    public interface ICalculationService
    {
        float Calculate(CalculationModel calculationModel);
    }
}
