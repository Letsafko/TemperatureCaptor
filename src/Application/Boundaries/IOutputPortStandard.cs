namespace Application.Boundaries
{
    public interface IOutputPortStandard<in TUseCaseOutput>
    {
        /// <summary>
        ///     Writes to the Standard Output.
        /// </summary>
        /// <param name="output">output port message.</param>
        void Standard(TUseCaseOutput output);
    }
}
