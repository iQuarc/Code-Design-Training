using Microsoft.Extensions.DependencyInjection;

namespace LessonsSamples.Lesson6
{
    public static class NetCoreContainerDemo
    {
        public static void MainFunc()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<MovieConsoleApplication>();
            app.Run();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddTransient<ICommand, MovieConsoleCreator>()
                .AddTransient<ICommand, MovieTranslator>()
                .AddTransient<ITextStorage, FileStorage>()

                // Demo the difference between Scoped and Transient. This being the root container, Scoped will be promoted to Singleton
                .AddTransient<MovieConsoleApplication, MovieConsoleApplication>()

                ;
        }
    }
}