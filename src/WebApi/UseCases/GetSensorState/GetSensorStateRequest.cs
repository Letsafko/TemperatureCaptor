namespace WebApi.UseCases.GetSensorState
{
    /// <summary>
    /// Get sensor state request.
    /// </summary>
    public sealed class GetSensorStateRequest
    {
        /// <summary>
        /// requested temperature
        /// </summary>
        public double Temperature { get; set; }
    }
}
