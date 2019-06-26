using System;

namespace MyCsProgram
{
    /// <summary>
    /// Rectangle Command. Draws rectangle.
    /// </summary>
    /// <seealso cref="MyCsProgram.CommandOutput" />
    /// <seealso cref="MyCsProgram.ICommand" />
    internal class RectCommand : CommandOutput, ICommand
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectCommand"/> class.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        public RectCommand(string x1, string y1, string x2, string y2)
        {
            if (!int.TryParse(x1, out _x1) ||
                !int.TryParse(y1, out _y1) ||
                !int.TryParse(x2, out _x2) ||
                !int.TryParse(y2, out _y2))
                IsValid = false;
            else
                IsValid = true;
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        public CommandType CommandType => CommandType.RECT;

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
        public void Execute()
        {
            var vLen = Math.Abs(_y1 - _y2) + 1;
            var hLen = Math.Abs(_x1 - _x2) + 1;
            for (int i = 0; i < vLen; i++)
            {
                int rowIndex = _y1 + i;
                for (int j = 0; j < hLen; j++)
                {
                    if ((i > 0 && i < vLen - 1) &&
                        (j > 0 && j < hLen - 1))
                    {
                        continue;
                    }
                    int colIndex = _x1 + j;
                    if (data[rowIndex][colIndex] == ' ')
                    {
                        data[rowIndex] = data[rowIndex]
                            .Remove(colIndex, 1)
                            .Insert(colIndex, PrintChar);
                    }
                }
            }
        }
    }
}
