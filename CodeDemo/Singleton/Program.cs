using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cannot instanciate it
            //ApplicationSettings applicationSettings = new ApplicationSettings();

            ApplicationSettings applicationSettings = ApplicationSettings.Instance();

            applicationSettings.ToConsole();
           

            ApplicationSettings copy2OfApplicationSettings = ApplicationSettings.Instance();
            applicationSettings.ToConsole();

            Console.ReadLine();
        }
    }
}
