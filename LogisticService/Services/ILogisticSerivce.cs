using LogisticService.Services.Models;

namespace LogisticService.Services
{
    public interface ILogisticSerivce
    {
        float GetPrice(LogisticModel logisticModel);
    }
}
