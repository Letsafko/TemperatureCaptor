namespace Application.Boundaries.GetTemperaturesRequested
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public sealed class GetTemperaturesRequestedInput
    {
        public GetTemperaturesRequestedInput(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}
