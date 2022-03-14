using System.Threading.Tasks;

namespace Application.Boundaries
{
    public interface IUseCase<in TUseCaseInput>
    {
        /// <summary>
        ///     Executes a use case.
        /// </summary>
        /// <param name="input">input message.</param>
        /// <returns>Task.</returns>
        Task ExecuteAsync(TUseCaseInput input);
    }
}
