namespace MyCsProgram
{
    /// <summary>
    /// Quit Command Class.
    /// </summary>
    /// <seealso cref="MyCsProgram.CommandOutput" />
    /// <seealso cref="MyCsProgram.ICommand" />
    internal class QuitCommand : CommandOutput, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuitCommand"/> class.
        /// </summary>
        public QuitCommand()
        {
            IsValid = true;
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        public CommandType CommandType => CommandType.QUIT;

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute()
        {

        }
    }
}
