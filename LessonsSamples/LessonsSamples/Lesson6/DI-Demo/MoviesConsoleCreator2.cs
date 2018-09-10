using System;

namespace LessonsSamples.Lesson6
{
    class MoviesConsoleCreator2 : ICommand
    {
        private readonly IEntityReader entityReader;
        private readonly IConsole console;
        private readonly IFileRepository repository;

        public MoviesConsoleCreator2(IEntityReader entityReader, IConsole console, IFileRepository repository)
        {
            this.entityReader = entityReader;
            this.console = console;
            this.repository = repository;
        }

        public void Execute()
        {
            Console.WriteLine("Follow instructions to insert movies");
            Console.WriteLine("Press ESC when you are done.");
            Console.WriteLine();
            string readMore = string.Empty;
            do
            {
                console.WriteLine("------ Enter data for a new Movie ---------");

                var fieldsReader = entityReader.BeginEntityRead<Movie>();
                foreach (var field in fieldsReader.GetFields())
                {
                    var value = console.AskInput($"Enter value for: Movie.{field}: ");
                    fieldsReader.StoreFieldValue(field, value);
                }

                Movie m = fieldsReader.GetEntity();
                repository.Add(m);

                readMore = console.AskInput("Enter another movie? [Y/N]");

            } while (string.Compare(readMore, "y", StringComparison.InvariantCultureIgnoreCase)== 0);

            Console.WriteLine();
            Console.WriteLine("Thank you!. Your movies were created");
        }

        public char KeyChar => '3';
        public string MenuEntry => "Create movies";
    }
}