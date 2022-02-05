using ResortForecaster.Enums;

namespace ResortForecaster.Models
{
    public class Feedback : Base
    {
        public string Description { get; set; }
        public FeedbackType FeedbackTypeId { get; set; }
    }
}
