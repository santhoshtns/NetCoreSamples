namespace MyCsProgram
{
    /// <summary>
    /// Canvas Command Class. Draws the rectangle.
    /// </summary>
    /// <seealso cref="MyCsProgram.CommandOutput" />
    /// <seealso cref="MyCsProgram.ICommand" />
    internal class CanvasCommand : CommandOutput, ICommand
    {
        private int _width;
        private int _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasCommand"/> class.
        /// </summary>
        /// <param name="w">The w.</param>
        /// <param name="h">The h.</param>
        public CanvasCommand(string w, string h)
        {
            if (!int.TryParse(w, out _width) ||
                !int.TryParse(h, out _height))
                IsValid = false;
            else
                IsValid = true;
            data = new System.Collections.Generic.List<string>();
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        public CommandType CommandType => CommandType.CANVAS;

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; }

        /// <summary>
        /// Executes the Canvas Command.
        /// </summary>
        public void Execute()
        {
            data.Clear();

            var topBottom = new string('-', _width + 2);
            var leftRight = $"|{new string(' ', _width)}|";

            data.Add(topBottom);
            for (int i = 0; i < _height; i++)
            {
                data.Add(leftRight);
            }
            data.Add(topBottom);
        }
    }
}
