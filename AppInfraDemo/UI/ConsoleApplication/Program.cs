using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;
using iQuarc.DataAccess.AppBoot;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleApplication
{
	internal class Program
	{
		private static void Main(string[] args)
		{
		    SetupDataDirectory();
			Bootstrapp();

			Console.WriteLine();
			Console.WriteLine("Press any key to close the application...");
			Console.ReadKey();
		}

	    private static IServiceLocator Bootstrapp()
		{
			var assemblies = GetApplicationAssemblies().ToArray();
			Bootstrapper bootstrapper = new Bootstrapper(assemblies);
			bootstrapper.ConfigureWithUnity();
			bootstrapper.AddRegistrationBehavior(new ServiceRegistrationBehavior());
			bootstrapper.AddRegistrationBehavior(DataAccessConfigurations.DefaultRegistrationConventions);

			bootstrapper.Run();

			return bootstrapper.ServiceLocator;
		}

	    private static IEnumerable<Assembly> GetApplicationAssemblies()
		{
		    yield return Assembly.GetExecutingAssembly();

		    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		    foreach (string dll in Directory.GetFiles(path, "*.dll"))
			{
				string filename = Path.GetFileName(dll);
				if (filename != null && (filename.StartsWith("Common")
										 || filename.StartsWith("Contracts")
										 || filename.StartsWith("DataAccess")
										 || filename.StartsWith("iQuarc.DataAccess")
										 || filename.StartsWith("Export.")
										 || filename.StartsWith("Notifications.")
										 || filename.StartsWith("Sales.")
					))
				{
					Assembly assembly = Assembly.LoadFile(dll);
					yield return assembly;
				}
			}
		}

	    private static void SetupDataDirectory()
	    {
	        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
	        AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\.App_Data")));
	    }
	}
}