using System.Drawing;
using CommonServiceLocator;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace LessonsSamples.Lesson6
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();
			

			container.RegisterType<ICommand, MoviesConsoleCreator2>(nameof(MoviesConsoleCreator2));
			container.RegisterType<ICommand, MovieTranslator>(nameof(MovieTranslator));
            container.RegisterType<ITextStorage, FileStorage>(new PerResolveLifetimeManager());

            container.RegisterType<IConsole, AppConsole>();
            container.RegisterType<IEntityReader, Unity.EntityReader>();
            container.RegisterType<IEntityFieldsReader<Movie>, MovieFieldsReader>();
            container.RegisterType<IFileRepository, InMemoryFileRepository>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            var app = ServiceLocator.Current.GetInstance<MovieConsoleApplication>();
			app.Run();
		}
	}
}