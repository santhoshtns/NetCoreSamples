using System;

namespace MyCsProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand command = null;
            var commandInvoker = new CommandInvoker();
            bool isQuitCommand = false;
            while (!isQuitCommand)
            {
                try
                {
                    Console.WriteLine("Enter the command");
                    var input = Console.ReadLine();
                    var inputSplit = input.Split(' ');
                    switch (inputSplit[0])
                    {
                        case "C":
                            command = new CanvasCommand(inputSplit[1], inputSplit[2]);
                            break;
                        case "L":
                            command = new LineCommand(inputSplit[1], inputSplit[2], inputSplit[3], inputSplit[4]);
                            break;
                        case "R":
                            command = new RectCommand(inputSplit[1], inputSplit[2], inputSplit[3], inputSplit[4]);
                            break;
                        case "B":
                            command = new FillCommand(inputSplit[1], inputSplit[2], inputSplit[3]);
                            break;
                        case "Q":
                            isQuitCommand = true;
                            break;
                        default:
                            break;
                    }

                    if (command != null && command.IsValid)
                    {
                        commandInvoker.AddCommand(command);
                        command = null;
                        Console.Clear();
                        commandInvoker.Invoke();
                        commandInvoker.Print();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
