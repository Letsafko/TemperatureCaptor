namespace Application.Boundaries
{
    /// <summary>
    ///     Error Output Port.
    /// </summary>
    public interface IOutputPortError
    {
        /// <summary>
        ///     Informs an error happened.
        /// </summary>
        /// <param name="message">Text description.</param>
        void WriteError(string message);
    }
}
