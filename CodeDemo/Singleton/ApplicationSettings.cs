using System;

namespace Singleton
{
    public class ApplicationSettings
    {
        private static ApplicationSettings _instance = new ApplicationSettings();
        private int _sessionCount = 0;

        private ApplicationSettings()
        {
            
        }

        public static ApplicationSettings Instance()
        {
            _instance._sessionCount++;

            return _instance;
        }

        public string ApplicationName
        {
            get { return "AcmeErp"; }
        }

        public string Version
        {
            get { return "1.3.1"; }
        }

        public int SessionCount
        {
            get { return _sessionCount; }
        }

        public void ToConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Application Name: {0}", ApplicationName);
            Console.WriteLine("Version: {0}", Version);
            Console.WriteLine("Session Count: {0}", _sessionCount);
        }
    }
}