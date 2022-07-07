using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    internal class ConnectionSpecification
    {
        public string IP { get; set; }
        public int Port { get; set; }

        public ConnectionSpecification(string _IP, int _Port)
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
            if (Port >= 65535)
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
    }
}
