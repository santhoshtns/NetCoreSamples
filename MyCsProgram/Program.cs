using System;

namespace MyCsProgram
{
    /// <summary>
    /// Main Program Class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            ICommand command = null;
            var commandInvoker = new CommandInvoker();
            bool isQuitCommand = false;
            while (!isQuitCommand)
            {
                try
                {
                    ShowHelp();
                    var input = Console.ReadLine();
                    command = CommandFactory.CreateCommand(input);
                    if (command != null &&
                        command.CommandType != CommandType.QUIT)
                    {
                        commandInvoker.AddCommand(command);
                        command = null;
                        Console.Clear();
                        commandInvoker.Invoke();
                        commandInvoker.Print();
                    }
                    else if (command != null &&
                        command.CommandType == CommandType.QUIT)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        /// <summary>
        /// Shows the help text.
        /// </summary>
        private static void ShowHelp()
        {
            Console.WriteLine("Command Types:");
            Console.WriteLine("Canvas Command: C w h");
            Console.WriteLine("\tShould create a new canvas of width w and height h.");
            Console.WriteLine("Line Command: L x1 y1 x2 y2");
            Console.WriteLine("\tShould create a new line from (x1,y1) to (x2,y2). Currently only\n" +
                "\thorizontal or vertical lines are supported. Horizontal and vertical lines\n" +
                "\twill be drawn using the 'x' character.");
            Console.WriteLine("Rectangle Command: R x1 y1 x2 y2");
            Console.WriteLine("\tShould create a new rectangle, whose upper left corner is (x1,y1) and\n" +
                "\tlower right corner is (x2,y2). Horizontal and vertical lines will be drawn\n" +
                "\tusing the 'x' character.");
            Console.WriteLine("Fill Command: B x y c");
            Console.WriteLine("\tShould fill the entire area connected to (x,y) with 'colour' c. The\n" +
                "\tbehavior of this is the same as that of the 'bucket fill' tool in \n" +
                "\tprograms.");
            Console.WriteLine("Quit Command: Q");
            Console.WriteLine("\tShould quit the program");
            Console.WriteLine("Enter the Command:");
        }
    }
}
