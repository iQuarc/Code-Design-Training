using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuarc.AppBoot;
using LessonsSamples.Lesson6;
using LessonsSamples.Lesson6.CoreContainerConstructorSelection;
using LessonsSamples.Lesson6.CoreContainerLifetime;
using LessonsSamples.Lesson6.ServiceLocatorTestability;

namespace LessonsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRunner.RunTests();

            //UnityDemo.MainFunc();
            
            NetCoreContainerDemo.MainFunc();
            //NetCoreConstructorSelectionDemo.MainFunc();
            //NetCoreLifetimeDemo.MainFunc();

            Console.WriteLine();
            Console.WriteLine("Demo ran. Press enter to close");
            Console.ReadLine();
        }
    }
}
