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

            bool successful = false;

            do
            {
                try
                {
                    string log;

                    if (LogNumber == 0)
                    {
                        log = "==============================\r\nLog Entry :\r\n\r\n";
                        StreamWriter writer = File.AppendText(LogCurrentDirectory + LogFileName);
                        writer.WriteLine(log);
                        CurrentSessionLogs.Add(log);
                        writer.Close();
                    }

                    log = string.Format("[{0} | {1}]\r\n{2} : {3}\r\n", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), LogNumber, logMessage);

                    do
                    {
                        if (!IsFileLocked())
                        {
                            StreamWriter writer = File.AppendText(LogCurrentDirectory + LogFileName);
                            writer.WriteLine(log);
                            CurrentSessionLogs.Add(log);
                            writer.Close();
                            successful = true;
                        }
                    } while (IsFileLocked());

                    LogNumber++;
                }
                catch
                {
                    successful = false;
                }
            } while (!successful);


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
            try
            {
                if (File.Exists(LogCurrentDirectory + LogFileName))
                {
                    FileInfo info = new FileInfo(LogCurrentDirectory + LogFileName);
                    if ((info.Length / (1024 * 1024)) >= 3.0f)
                    {
                        List<string> logs = File.ReadAllLines(LogCurrentDirectory + LogFileName).ToList();
                        int firstIndex = logs.IndexOf("Log Entry :");
                        int nextIndex = logs.IndexOf("Log Entry :", firstIndex) - 1;
                        logs.RemoveRange(firstIndex, nextIndex - firstIndex);

                        do
                        {
                            if (!IsFileLocked())
                            {
                                File.WriteAllLines(LogCurrentDirectory + LogFileName, logs.ToArray());
                            }
                        } while (IsFileLocked());

                    }
                }
            }
            catch { }

            if (CurrentSessionLogs.Count >= 32767)
            {
                CurrentSessionLogs.RemoveAt(0);
            }
        }

        private static bool IsFileLocked()
        {
            FileInfo file = new FileInfo(LogCurrentDirectory + LogFileName);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
    }

    internal static class ActionLog
    {
        public static long LogNumber { get; private set; } = 0;
        public static string LogCurrentDirectory { get; } = (Directory.GetCurrentDirectory() + "/");
        public static string LogFileName { get; } = "action_log.txt";


        public static List<string> CurrentSessionLogs { get; set; } = new List<string>();


        public static void Register(string logMessage)
        {
            OversizeProtection();

            bool successful = false;

            do
            {
                try
                {
                    string log;

                    if (LogNumber == 0)
                    {
                        log = "==============================\r\nAction Log Entry :\r\n\r\n";
                        StreamWriter writer = File.AppendText(LogCurrentDirectory + LogFileName);
                        writer.WriteLine(log);
                        CurrentSessionLogs.Add(log);
                        writer.Close();
                    }

                    log = $"[{DateTime.Now.ToLongDateString()} | {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}.{DateTime.Now.Millisecond} {DateTime.Now.TimeOfDay}]\r\n{LogNumber} : {logMessage}\r\n";

                    do
                    {
                        if (!IsFileLocked())
                        {
                            StreamWriter writer = File.AppendText(LogCurrentDirectory + LogFileName);
                            writer.WriteLine(log);
                            CurrentSessionLogs.Add(log);
                            writer.Close();
                            successful = true;
                        }
                    } while (IsFileLocked());

                    LogNumber++;
                }
                catch
                {
                    successful = false;
                }
            } while (!successful);


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
            try
            {
                if (File.Exists(LogCurrentDirectory + LogFileName))
                {
                    FileInfo info = new FileInfo(LogCurrentDirectory + LogFileName);
                    if ((info.Length / (1024 * 1024)) >= 3.0f)
                    {
                        List<string> logs = File.ReadAllLines(LogCurrentDirectory + LogFileName).ToList();
                        int firstIndex = logs.IndexOf("Action Log Entry :");
                        int nextIndex = logs.IndexOf("Action Log Entry :", firstIndex) - 1;
                        logs.RemoveRange(firstIndex, nextIndex - firstIndex);

                        do
                        {
                            if (!IsFileLocked())
                            {
                                File.WriteAllLines(LogCurrentDirectory + LogFileName, logs.ToArray());
                            }
                        } while (IsFileLocked());

                    }
                }
            }
            catch { }

            if (CurrentSessionLogs.Count >= 32767)
            {
                CurrentSessionLogs.RemoveAt(0);
            }
        }

        private static bool IsFileLocked()
        {
            FileInfo file = new FileInfo(LogCurrentDirectory + LogFileName);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
    }

}
