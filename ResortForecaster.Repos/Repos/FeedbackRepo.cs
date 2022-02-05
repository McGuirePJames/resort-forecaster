using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;

namespace ResortForecaster.Repos.Repos
{
    public class FeedbackRepo : BaseRepo<Feedback>, IFeedbackRepo
    {
        public FeedbackRepo(ResortForecasterContext dbContext) : base(dbContext)
        {
        }
    }
}
