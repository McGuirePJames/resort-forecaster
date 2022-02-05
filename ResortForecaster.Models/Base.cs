using System.ComponentModel.DataAnnotations;

namespace ResortForecaster.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
