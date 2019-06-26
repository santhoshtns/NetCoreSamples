namespace MyCsProgram
{
    interface ICommand
    {
        CommandType CommandType { get; }
        bool IsValid { get; }
        void Execute();
    }
}
