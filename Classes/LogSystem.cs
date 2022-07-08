using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    internal static class Log
    {
        public static long LogNumber { get; set; } = 0;
        public static string LogCurrentDirectory { get; set; } = (Directory.GetCurrentDirectory() + "/");
        public static string LogFileName { get; set; } = "log.txt";


        public static List<string> CurrentSessionLogs { get; set; } = new List<string>();


        public static void Register(string logMessage)
        {
            OversizeProtection();
            using (StreamWriter writer = File.AppendText(LogCurrentDirectory + LogFileName))
            {
                string log;

                if (LogNumber == 0)
                {
                    log = "==============================\r\nLog Entry :\r\n";
                    writer.WriteLine(log);
                    CurrentSessionLogs.Add(log);
                }

                log = string.Format("[{0} | {1}]\r\n{2} : {3}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), LogNumber, logMessage);
                writer.WriteLine(log);
                CurrentSessionLogs.Add(log);

                LogNumber++;
            }
        }

        public static string Read()
        {
            if (File.Exists(LogCurrentDirectory + LogFileName))
            {
                using (StreamReader reader = File.OpenText(LogCurrentDirectory + LogFileName))
                {
                    return reader.ReadToEnd();
                }
            }
            return "";
        }

        public static string ReadCurrentLog()
        {
            return string.Join("\r\n", CurrentSessionLogs);
        }

        public static void OversizeProtection()
        {
            if (File.Exists(LogCurrentDirectory + LogFileName))
            {
                FileInfo info = new FileInfo(LogCurrentDirectory + LogFileName);
                if ((info.Length / (1024 * 1024)) >= 3.0f)
                {
                    List<string> logs = File.ReadAllLines(LogCurrentDirectory + LogFileName).ToList();
                    int firstIndex = logs.IndexOf("Log Entry :");
                    int nextIndex = logs.IndexOf("Log Entry :", firstIndex);
                    logs.RemoveRange(firstIndex, nextIndex - firstIndex);
                    File.WriteAllLines(LogCurrentDirectory + LogFileName, logs.ToArray());
                }
            }

            if (CurrentSessionLogs.Count >= 32767)
            {
                CurrentSessionLogs.RemoveAt(0);
            }
        }
    }
}
