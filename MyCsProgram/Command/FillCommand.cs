using System;

namespace MyCsProgram
{
    /// <summary>
    /// Fill Command
    /// </summary>
    /// <seealso cref="MyCsProgram.CommandOutput" />
    /// <seealso cref="MyCsProgram.ICommand" />
    class FillCommand : CommandOutput, ICommand
    {
        private int _x;
        private int _y;
        private string _color;

        /// <summary>Initializes a new instance of the <see cref="FillCommand"/> class.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        public FillCommand(string x, string y, string color)
        {
            if (!int.TryParse(x, out _x) ||
                !int.TryParse(y, out _y))
                IsValid = false;
            else
                IsValid = true;
            this._color = color;
        }

        public CommandType CommandType => CommandType.FILL;

        public bool IsValid { get; }

        public void Execute()
        {
            Fill(_x, _y);
        }

        private void Fill(int x, int y)
        {
            if (y > 0 && y < data.Count - 1 &&
                x > 0 && x < data[0].Length - 1 &&
                data[y][x] == ' ')
            {
                data[y] = data[y]
                    .Remove(x, 1)
                    .Insert(x, _color);
                Fill(x - 1, y);
                Fill(x + 1, y);
                Fill(x, y - 1);
                Fill(x, y + 1);
            }
        }
    }
}
