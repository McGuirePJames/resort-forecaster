using ResortForecaster.Enums;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Mutations
{
    [ExtendObjectType(name: "Mutation")]
    public class FeedbackMutation
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackMutation(IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
        }

        public async Task<MutationResponse> AddFeedbackAsync(string description, int feedbackTypeId)
        {
            try
            {
                await this._feedbackService.CreateAsync(new Feedback()
                {
                    Description = description,
                    FeedbackTypeId = (FeedbackType)feedbackTypeId,
                });

                return new MutationResponse()
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new MutationResponse()
                {
                    Success = false,
                    Errors = new List<string>() { ex.Message }
                };
            }

        }
    }
}
