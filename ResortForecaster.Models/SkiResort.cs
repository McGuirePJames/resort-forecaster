using System.ComponentModel.DataAnnotations;

namespace ResortForecaster.Models
{
    public class SkiResort
    {
        [Key]
        public Guid SkiResortId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
