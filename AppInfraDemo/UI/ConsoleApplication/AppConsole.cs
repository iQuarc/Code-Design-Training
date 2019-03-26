using System;
using Contracts.ConsoleUi;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace ConsoleApplication
{
    [Service(typeof(IConsole), Lifetime.Application)]
    class AppConsole : IConsole
    {
        public string AskInput(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public void WriteEntity<T>(T entity)
        {
            Console.WriteLine();
            Console.WriteLine($"--------------- {typeof(T).Name} ----------------");
            var properties = ReflectionExtensions.GetEditableSimpleProperties(entity);
            foreach (var propertyInfo in properties)
            {
                Console.Write($"{propertyInfo.Name}: ");
                Console.WriteLine(propertyInfo.GetValue(entity));
            }

            Console.WriteLine("-----------------------------------------------------");
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}