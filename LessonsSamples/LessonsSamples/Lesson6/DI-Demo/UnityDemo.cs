using Unity;
using Unity.Lifetime;

namespace LessonsSamples.Lesson6
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();

			container.RegisterType<ICommand, MoviesConsoleCreator>(nameof(MoviesConsoleCreator));
			container.RegisterType<ICommand, MovieTranslator>(nameof(MovieTranslator));

			// Demo the difference between PerResolveLifetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new TransientLifetimeManager()); 


			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}
	}
}