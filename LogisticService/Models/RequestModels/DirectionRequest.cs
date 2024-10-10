namespace LogisticService.Models.RequestModels
{
    public class DirectionRequest
    {
        public DirectionRequest(string from, string to)
        {
            From1 = from;
            To1 = to;
        }

        public string From1 { get; set; }
        public string To1 { get; set; }
    }
}
