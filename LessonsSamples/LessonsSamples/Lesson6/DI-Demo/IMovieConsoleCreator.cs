using System;

namespace LessonsSamples.Lesson6
{
	class MovieConsoleCreator : ICommand
	{
		private readonly ITextStorage storage;

		public MovieConsoleCreator(ITextStorage storage)
		{
			this.storage = storage;
		}

		public void Execute()
		{
			Console.WriteLine("Insert One Movie on each line.");
			Console.WriteLine("Press ESC when you are done.");
            Console.WriteLine();
			ConsoleKeyInfo c;
			do
			{
				c = Console.ReadKey();

				if (char.IsLetterOrDigit(c.KeyChar))
					storage.Write(new string(c.KeyChar, 1));
				else if (c.Key == ConsoleKey.Enter)
				{
					Console.WriteLine();
					storage.WriteLine(string.Empty);
				}

			} while (c.Key != ConsoleKey.Escape);

			Console.WriteLine();
			Console.WriteLine("Thank you!. Your movies were created");
		}

	    public char KeyChar => '1';
	    public string MenuEntry => "Create movies";
	}
}