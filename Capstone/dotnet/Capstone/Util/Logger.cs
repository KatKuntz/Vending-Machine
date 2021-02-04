using System;
using System.IO;

namespace Capstone.Util
{
    static class Logger
    {
        private const string logFile = @"Log.txt";

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFile))
            {
                writer.WriteLine($"{GetTimestamp()} {message}");
            }
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString();
        }
    }
}
