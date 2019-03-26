namespace ConsoleApplication
{
    public interface IConsoleCommand
    {
        void Execute();
        string MenuLabel { get; }
    }
}