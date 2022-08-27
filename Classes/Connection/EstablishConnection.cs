using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    public enum Positions : byte
    {
        Server = 0,
        Client = 1
    }

    public enum ConnectionMethods : byte
    {
        TCP = 0,
        UDP = 1
    }

    public static class EstablishConnection
    {
        private static Positions? Position { get; set; } = null;
        private static ConnectionSpecification ConnectionSpecification { get; set; } = new ConnectionSpecification("");
        private static ConnectionMethods? ConnectionMethod { get; set; } = null;
        private static bool ServerStatus { get; set; } = false;
        private static object? Server { get; set; } = null;

        #region Specifications Properties

        #region Set Specifications

        public static bool SetConnectionSpecification(string? ip = null, int? port = null)
        {
            if (!ServerStatus)
            {
                ConnectionSpecification = new ConnectionSpecification(ip != null ? ip : ConnectionSpecification.IP, port != null ? (int)port : ConnectionSpecification.Port);
                return true;
            }
            Log.Register("Can Not Change The Connection While Server is Running");
            return false;
        }

        public static bool SetPosition(Positions position)
        {
            if (!ServerStatus)
            {
                Position = position;
                return true;
            }
            Log.Register("Can Not Change The Connection While Server is Running");
            return false;
        }

        public static bool SetConnectionMethod(ConnectionMethods connectionMethod)
        {
            if (!ServerStatus)
            {
                ConnectionMethod = connectionMethod;
                return true;
            }
            Log.Register("Can Not Change The Connection While Server is Running");
            return false;
        }

        #endregion

        #region Get Specifications

        public static ConnectionSpecification GetConnectionSpecification()
        {
            return ConnectionSpecification;
        }

        public static Positions? GetPosition()
        {
            return Position;
        }

        public static ConnectionMethods? GetConnectionMethod()
        {
            return ConnectionMethod;
        }

        public static bool GetServerStatus()
        {
            return ServerStatus;
        }

        #endregion

        #endregion

        #region Verification

        public static bool VerifySpecifications(bool skipServerChecking = false)
        {
            if (Position != null)
            {
                if ((ConnectionSpecification.ValidateIP() && ConnectionSpecification.ValidatePort()) || (Position == Positions.Server && ConnectionSpecification.IP == "" && ConnectionSpecification.ValidatePort()))
                {
                    if (ConnectionMethod != null)
                    {
                        if (Server != null || skipServerChecking)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Log.Register("Connection Method Has Not Been Set!");
                    }
                }
                else
                {
                    Log.Register("IP Address Or Port is Not Valid!");
                }
            }
            else
            {
                Log.Register("Device Position Has Not Been Set!");
            }
            return false;
        }

        #endregion

        #region Server Events

        public static bool ChangeServerStatus()
        {
            if (VerifySpecifications(true))
            {
                if (!GetServerStatus())
                {
                    if (CreateServer())
                    {
                        if (StartServer())
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (StopServer())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CreateServer()
        {
            if (VerifySpecifications(true))
            {
                if (Position == Positions.Server)
                {
                    switch (ConnectionMethod)
                    {
                        case ConnectionMethods.TCP:
                            Log.Register("Creating TCP Server ...");

                            Server = new TCPServer(IPAddress.Any, ConnectionSpecification.Port);

                            Log.Register("TCP Server Was Created");
                            return true;
                            break;

                        case ConnectionMethods.UDP:
                            break;
                    }
                }
                else if (Position == Positions.Client)
                {
                    switch (ConnectionMethod)
                    {
                        case ConnectionMethods.TCP:
                            Log.Register("Creating TCP Client Server ...");

                            Server = new TCPClient(ConnectionSpecification.IP, ConnectionSpecification.Port);

                            Log.Register("TCP Client Server Was Created");
                            return true;
                            break;

                        case ConnectionMethods.UDP:
                            break;
                    }
                }
            }
            return false;
        }

        public static bool StartServer()
        {
            Log.Register("Starting The Server ...");

            if (Server != null)
            {
                if (!ServerStatus)
                {
                    if (Position == Positions.Server)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPServer)Server).Start();
                                Log.Register("Server is Online!");
                                ServerStatus = true;
                                return true;
                                break;

                            case ConnectionMethods.UDP:
                                break;
                        }
                    }
                    else if (Position == Positions.Client)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPClient)Server).ConnectAsync();
                                Log.Register("Client Server is Online!");
                                ServerStatus = true;
                                return true;
                                break;

                            case ConnectionMethods.UDP:
                                break;
                        }
                    }
                }
                else
                {
                    Log.Register("Server is Online Already");
                }
            }
            else
            {
                Log.Register("Server Has Not Been Created!");
            }

            return false;
        }

        public static bool StopServer()
        {
            Log.Register("Stoping The Server ...");

            if (Server != null)
            {
                if (ServerStatus)
                {
                    if (Position == Positions.Server)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPServer)Server).Stop();
                                Log.Register("Server is Offline!");
                                ServerStatus = false;
                                return true;
                                break;

                            case ConnectionMethods.UDP:
                                break;
                        }
                    }
                    else if (Position == Positions.Client)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPClient)Server).DisconnectAndStop();
                                Log.Register("Server is Offline!");
                                ServerStatus = false;
                                return true;
                                break;

                            case ConnectionMethods.UDP:
                                break;
                        }
                    }
                }
                else
                {
                    Log.Register("Server is Offline Already");
                }
            }
            else
            {
                Log.Register("Server Has Not Been Created!");
            }

            return false;
        }

        public static void SendMessage(string message)
        {
            if (Server != null)
            {
                if (ServerStatus)
                {
                    if (Position == Positions.Server)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPServer)Server).SendMessage(message);
                                break;
                        }
                    }
                    else if (Position == Positions.Client)
                    {
                        switch (ConnectionMethod)
                        {
                            case ConnectionMethods.TCP:
                                ((TCPClient)Server).SendAsync(message);
                                break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
