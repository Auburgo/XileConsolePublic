using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XileConsole.Misc
{
    internal class Logger
    {
        private static readonly Logger instance = new Logger();
        static Logger() { } 
        private Logger() { } 

        public static Logger Instance { get { return instance; } }

        public static void Log(string message)
        {
            File.AppendAllText("log.txt", DateTime.Now + " - " + message +"\n");
        }
    }
}
