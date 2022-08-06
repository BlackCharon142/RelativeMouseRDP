using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    public class ConnectionSpecification
    {
        public string IP { get; set; }
        public int Port { get; set; } = 54321;

        public ConnectionSpecification(string _IP, int _Port = 54321)
        {
            IP = _IP;
            Port = _Port;
        }

        public bool ValidateIP()
        {
            if ((IP.Split('.').Length) == 4)
            {
                string[] splitParts = IP.Split('.');
                return splitParts.All(r => byte.TryParse(r, out _));
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateIP(string ip)
        {
            if ((ip.Split('.').Length) == 4)
            {
                string[] parts = ip.Split('.');
                return parts.All(r => byte.TryParse(r, out _));
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePort()
        {
            if (Port <= 65535)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePort(string port)
        {
            if (decimal.TryParse(port, out _))
            {
                if (decimal.Parse(port) <= 65535)
                {
                    return true;
                }
            }
            return false;
        }

        public string FullDetail()
        {
            return IP + ":" + Port;
        }

        public static string SplitIP(string fullDetail)
        {
            if (ValidateIP(fullDetail.Split(":")[0]))
            {
                return fullDetail.Split(":")[0];
            }
            else
            {
                return "*.*.*.*";
            }
        }

        public static int SplitPort(string fullDetail)
        {
            if (ValidatePort(fullDetail.Split(":")[1]))
            {
                return int.Parse(fullDetail.Split(":")[1]);
            }
            else
            {
                return -1;
            }
        }

    }
}
