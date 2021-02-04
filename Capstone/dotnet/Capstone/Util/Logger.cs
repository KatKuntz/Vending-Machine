using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Util
{
    static class Logger
    {
        private const string logFile = @"Log.txt";

        public static void Log(string message, decimal balance)
        {
            using (StreamWriter writer = new StreamWriter(logFile))
            {
                writer.WriteLine($"{GetTimestamp()} message\n{balance:C2}");
            }
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString();
        }
    }
}
