namespace MyCsProgram
{
    /// <summary>
    /// Command Factory Class.
    /// </summary>
    internal static class CommandFactory
    {
        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="input">The input command.</param>
        /// <returns></returns>
        public static ICommand CreateCommand(string input)
        {
            ICommand command = null;
            try
            {
                var inputSplit = input.Split(' ');
                switch (inputSplit[0])
                {
                    case "C":
                        command = new CanvasCommand(inputSplit[1], inputSplit[2]);
                        break;
                    case "L":
                        command = new LineCommand(inputSplit[1], inputSplit[2],
                            inputSplit[3], inputSplit[4]);
                        break;
                    case "R":
                        command = new RectCommand(inputSplit[1], inputSplit[2],
                            inputSplit[3], inputSplit[4]);
                        break;
                    case "B":
                        command = new FillCommand(inputSplit[1], inputSplit[2],
                            inputSplit[3]);
                        break;
                    case "Q":
                        command = new QuitCommand();
                        break;
                    default:
                        break;
                }

                if (command != null && !command.IsValid)
                {
                    command = null;
                }
            }
            catch (System.Exception)
            {
                command = null;
            }
            return command;
        }
    }
}
