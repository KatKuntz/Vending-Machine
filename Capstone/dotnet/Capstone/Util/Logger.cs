using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Util
{
    static class Logger
    {
        private const string logFile = @"Log.txt";

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFile))
            {
                writer.WriteLine(message);
            }
        }
    }
}
