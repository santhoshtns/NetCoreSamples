using System.Collections.Generic;

namespace MyCsProgram
{
    /// <summary>
    /// Command Invoker Class. Executes the commands.
    /// </summary>
    internal class CommandInvoker
    {
        private IList<ICommand> commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInvoker"/> class.
        /// </summary>
        public CommandInvoker()
        {
            commands = new List<ICommand>();
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Execute();
            }
        }

        /// <summary>
        /// Prints this instance.
        /// </summary>
        public void Print()
        {
            if (commands.Count > 0 && commands[0] != null)
            {
                (commands[0] as CommandOutput)?.Print();
            }
        }
    }
}
