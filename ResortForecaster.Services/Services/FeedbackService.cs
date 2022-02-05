using Microsoft.Extensions.Logging;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class FeedbackService : BaseEntityService<Feedback>, IFeedbackService
    {
        public FeedbackService(IBaseRepo<Feedback> baseRepo, ILogger<BaseEntityService<Feedback>> logger) : base(baseRepo, logger)
        {

        }
    }
}
