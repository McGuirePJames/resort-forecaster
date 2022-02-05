namespace ResortForecaster.Models
{
    public class MutationResponse
    {
        public MutationResponse()
        {
            this.Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
