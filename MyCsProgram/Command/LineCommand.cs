using System;

namespace MyCsProgram
{
    /// <summary>
    /// Line Command Class. Draws the line.
    /// </summary>
    /// <seealso cref="MyCsProgram.CommandOutput" />
    /// <seealso cref="MyCsProgram.ICommand" />
    internal class LineCommand : CommandOutput, ICommand
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineCommand"/> class.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        public LineCommand(string x1, string y1, string x2, string y2)
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
        public CommandType CommandType => CommandType.LINE;

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
            if (_x1 == _x2)
            {
                var len = Math.Abs(_y1 - _y2) + 1;
                var start = _y1 > _y2 ? _y2 : _y1;
                var colIndex = _x1;
                for (int i = 0; i < len; i++)
                {
                    int rowIndex = start + i;
                    if (data[rowIndex][colIndex] == ' ')
                    {
                        data[rowIndex] = data[rowIndex].Remove(colIndex, 1).Insert(colIndex, PrintChar);
                    }
                }
            }
            else if (_y1 == _y2)
            {
                var len = Math.Abs(_x1 - _x2) + 1;
                var start = _x1 > _x2 ? _x2 : _x1;
                for (int i = 0; i < len; i++)
                {
                    int colIndex = start + i;
                    if (data[_y1][colIndex] == ' ')
                    {
                        data[_y1] = data[_y1].Remove(colIndex, 1)
                            .Insert(colIndex, PrintChar);
                    }
                }
            }
        }
    }
}
