using System.Collections.Generic;

namespace MyCsProgram
{
    class CommandInvoker
    {
        IList<ICommand> commands;

        public CommandInvoker()
        {
            commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void Invoke()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Execute();
            }
        }

        public void Print()
        {
            if (commands.Count > 0 && commands[0] != null)
            {
                (commands[0] as CommandOutput)?.Print();
            }
        }
    }
}
