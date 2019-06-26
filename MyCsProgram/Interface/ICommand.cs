namespace MyCsProgram
{
    /// <summary>
    /// ICommand Interface.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        CommandType CommandType { get; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid { get; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        void Execute();
    }
}
