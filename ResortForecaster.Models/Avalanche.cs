namespace ResortForecaster.Models
{
    public class Avalanche : Base
    {
        public string? ExternalId { get; set; }
        public DateTime? Date { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Elevation { get; set; }
        public string? Aspect { get; set; }
        public string? Type { get; set; }
        public string? Cause { get; set; }
        public int? Depth { get; set; }
        public int? Width { get; set; }
    }
}
