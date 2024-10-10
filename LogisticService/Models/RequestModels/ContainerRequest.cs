namespace LogisticService.Models.RequestModels
{
    public class ContainerRequest
    {
        public bool IsClosed { get; set; }

        public ContainerRequest(bool isClosed)
        {
            IsClosed = isClosed;
        }
    }
}
