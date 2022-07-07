using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    abstract class LogSystem
    {
        public abstract void Log(string logMessage);
    }

    internal class Logger
    {
        public string LogCurrentDirectory { get; set; }
        public string LogFileName { get; set; }

        public Logger()
        {
            this.LogCurrentDirectory = Directory.GetCurrentDirectory() + "/";
            this.LogFileName = "log.txt";
        }

    }
}
