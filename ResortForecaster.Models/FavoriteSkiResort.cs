using System.ComponentModel.DataAnnotations;

namespace ResortForecaster.Models
{
    public class FavoriteSkiResort : Base
    {
        public Guid SkiResortId { get; set; }
        public string UserId { get; set; } = "";
    }
}
