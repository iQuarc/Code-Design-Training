using System.Collections.Generic;
using System.Linq;
using Contracts.ConsoleUi;
using iQuarc.AppBoot;

namespace ConsoleApplication
{
    [Service(nameof(ConsoleUiModule), typeof(IModule))]
    class ConsoleUiModule : IModule
    {
        private readonly IConsole console;
        private readonly Dictionary<string, IConsoleCommand> commands;

        public ConsoleUiModule(IConsoleCommand[] commands, IConsole console)
        {
            this.console = console;
            this.commands = commands
                .Select((c, i) => new {Command = c, Index = i})
                .ToDictionary(c => $"{c.Index + 1}", c => c.Command);
        }

        public void Initialize()
        {
            string commandId;
            do
            {
                WriteMenu();
                commandId = console.AskInput("Please type the command ID that you want to execute: ");

                if (commands.TryGetValue(commandId, out var command))
                {
                    console.Clear();

                    command.Execute();

                    console.WriteLine(string.Empty);
                    console.WriteLine("---------- The command execution is finished. Press ENTER to continue --------");
                    console.ReadLine();
                    console.Clear();
                }

            } while (commandId != "0");
        }

        private void WriteMenu()
        {
            console.WriteLine("----------- Available Commands --------------");
            console.WriteLine(string.Empty);

            foreach (var cmd in commands)
            {
                console.WriteLine($"{cmd.Key}. {cmd.Value.MenuLabel}");
            }

            console.WriteLine(string.Empty);
            console.WriteLine("0. Exit");
        }
    }
}