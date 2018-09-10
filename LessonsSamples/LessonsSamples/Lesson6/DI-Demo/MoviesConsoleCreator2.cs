using System;

namespace LessonsSamples.Lesson6.Demo
{
    class MoviesConsoleCreator2 : ICommand
    {
        private readonly IEntityConsoleReader entityConsoleReader;
        private readonly IConsole console;
        private readonly IFileRepository repository;

        public MoviesConsoleCreator2(IEntityConsoleReader entityConsoleReader, IConsole console, IFileRepository repository)
        {
            this.entityConsoleReader = entityConsoleReader;
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

                var fieldsReader = entityConsoleReader.BeginEntityRead<Movie>();
                foreach (var field in fieldsReader.GetFields())
                {
                    var value = console.AskInput($"Enter value for: Movie.{field}: ");
                    fieldsReader.StoreFieldValue(value);
                }

                Movie m = fieldsReader.GetEntity();
                repository.Save(m);

                string c = console.AskInput("Enter another movie? [Y/N]");

            } while (string.Compare(readMore, "y", StringComparison.InvariantCultureIgnoreCase)== 0);

            Console.WriteLine();
            Console.WriteLine("Thank you!. Your movies were created");
        }

        public char KeyChar => '3';
        public string MenuEntry => "Create movies";
    }

    internal interface IFileRepository
    {
        void Save(Movie movie);
    }
}