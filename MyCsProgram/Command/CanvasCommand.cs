using System;

namespace MyCsProgram
{
    internal class CanvasCommand : CommandOutput, ICommand
    {
        private int _width;
        private int _height;

        public CanvasCommand(string w, string h)
        {
            if (!int.TryParse(w, out _width) ||
                !int.TryParse(h, out _height))
                IsValid = false;
            else
                IsValid = true;
            data = new System.Collections.Generic.List<string>();
        }

        public CommandType CommandType => CommandType.CANVAS;

        public bool IsValid { get; }

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
