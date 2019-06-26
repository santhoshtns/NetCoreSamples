using System;

namespace MyCsProgram
{
    class RectCommand : CommandOutput, ICommand
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

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

        public CommandType CommandType => CommandType.RECT;

        public bool IsValid { get; }

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
