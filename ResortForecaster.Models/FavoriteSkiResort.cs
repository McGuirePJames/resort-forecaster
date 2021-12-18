using System.ComponentModel.DataAnnotations;

namespace ResortForecaster.Models
{
    public class FavoriteSkiResort
    {
        [Key]
        public Guid FavoriteSkiResortId { get; set; }
        public Guid SkiResortId { get; set; }
        public string UserId { get; set; }
    }
}
