namespace WebApi.UseCases.GetTemperaturesRequested
{
    /// <summary>
    /// Get last requested temperature.
    /// </summary>
    public class GetTemperaturesRequestedRequest
    {
        /// <summary>
        /// page size
        /// </summary>
        public int PageSize { get; set; } = 15;
    }
}
