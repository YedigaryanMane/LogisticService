namespace LogisticService.Models.RequestModels
{
    public class CrashedRequest
    {
        public bool IsCrashed { get; set; }

        public CrashedRequest(bool isCrashed)
        {
            IsCrashed = isCrashed;
        }
    }
}
