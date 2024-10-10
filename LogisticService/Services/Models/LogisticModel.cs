namespace LogisticService.Services.Models
{
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
}
