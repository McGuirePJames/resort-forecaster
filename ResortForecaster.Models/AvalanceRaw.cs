namespace ResortForecaster.Models
{
    public class AvalanceRaw
    {
        public string Id { get; set; }
        public string? Date { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Elevation { get; set; }
        public string Aspect { get; set; } = "";
        public string Type { get; set; } = "";
        public string Cause { get; set; } = "";
        public string? Depth { get; set; }
        public string? Width { get; set; }
    }
}
