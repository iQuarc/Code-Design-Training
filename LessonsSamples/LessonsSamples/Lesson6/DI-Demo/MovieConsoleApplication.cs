using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson6
{
    public class MovieConsoleApplication
    {
        private readonly IDictionary<char, ICommand> commands;

        public MovieConsoleApplication(IEnumerable<ICommand> commands)
        {
            this.commands = commands.ToDictionary(c => c.KeyChar);
        }

        public void Run()
        {
            WriteMenu();

            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey();
                WriteLineSeparator();

                if (commands.TryGetValue(c.KeyChar, out var cmd))
                {
                    cmd.Execute();
                }

                if (!IsExitKey(c))
                    WriteMenu();
            } while (!IsExitKey(c));
        }

        private void WriteMenu()
        {
            WriteLineSeparator();

            foreach (var cmd in commands.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{cmd.Key}. {cmd.Value.MenuEntry}");
            }

            Console.WriteLine();
            Console.WriteLine("0. Quit");

            Console.Write("Your command: ");
        }

        private static void WriteLineSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }

        private static bool IsExitKey(ConsoleKeyInfo c)
        {
            return c.KeyChar == '0' ||
                   c.Key == ConsoleKey.Escape ||
                   c.KeyChar == 'q' || c.KeyChar == 'Q';
        }
    }
}