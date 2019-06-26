using System;

namespace MyCsProgram
{
    class LineCommand : CommandOutput, ICommand
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

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

        public CommandType CommandType => CommandType.LINE;

        public bool IsValid { get; }

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
