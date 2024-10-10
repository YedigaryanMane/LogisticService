namespace LogisticService.Models.RequestModels
{
    public class CarTypeRequest
    {
        public string Type { get; set; }

        public CarTypeRequest(string type)
        {
            Type = type;
        }
    }
}
