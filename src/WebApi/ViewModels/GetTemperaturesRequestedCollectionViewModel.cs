namespace WebApi.ViewModels
{
    using Application.Boundaries.GetTemperaturesRequested;
    using System.Collections.Generic;

    public sealed class GetTemperaturesRequestedCollectionViewModel : List<GetTemperaturesRequestedViewModel>
    {
        public GetTemperaturesRequestedCollectionViewModel(IEnumerable<GetTemperaturesRequestedOutput> temperatures)
        {
            foreach (var temp in temperatures)
            {
                Add(new GetTemperaturesRequestedViewModel(temp.State, temp.Temperature));
            }
        }
    }
}
