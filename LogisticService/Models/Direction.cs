namespace LogisticService.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public decimal Price { get; set; }
        public double Distance { get; set; }
    }
}
