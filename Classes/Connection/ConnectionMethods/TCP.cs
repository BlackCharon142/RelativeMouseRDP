using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;

namespace RelativeMouseRDP
{
    #region Server

    class TCPSession : TcpSession
    {
        ConnectionSpecification clientSpecification;

        public TCPSession(TcpServer server) : base(server) { }

        protected override void OnConnected()
        {
            clientSpecification = new ConnectionSpecification(ConnectionSpecification.SplitIP(Socket.RemoteEndPoint.ToString()), ConnectionSpecification.SplitPort(Socket.RemoteEndPoint.ToString()));

            if (EstablishConnection.GetConnectionSpecification().IP != "")
            {
                if (EstablishConnection.GetConnectionSpecification().IP == clientSpecification.IP)
                {
                    string message = $"CC={clientSpecification.FullDetail()} : Accepted";
                    SendAsync(message);

                    Log.Register($"TCP Server Connection to Client({clientSpecification.FullDetail()}) was Successful!");
                }
                else
                {
                    string message = $"CC={clientSpecification.FullDetail()} : Rejected";
                    SendAsync(message);

                    Disconnect();

                    Log.Register($"TCP Server Connection to Client({clientSpecification.FullDetail()}) was Rejected!");
                }
            }
        }

        protected override void OnDisconnected()
        {
            Log.Register($"TCP Server Connection to Client({clientSpecification.FullDetail()}) Disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Log.Register("Incoming: " + message);

            InputData.OpenData(message);
            //if (message == "!x!")
            //    Disconnect();
        }

        protected override void OnError(SocketError error)
        {
            Log.Register($"TCP Server Connection to Client({clientSpecification.FullDetail()}) Encountered an Error : {error}");
        }
    }

    class TCPServer : TcpServer
    {
        TCPSession session;

        public TCPServer(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession()
        {
            session = new TCPSession(this);
            return session;
        }

        public bool SendMessage(string message)
        {
            if (this.IsStarted)
            {
                try
                {
                    session.SendAsync(message);
                    return true;
                }
                catch
                { }
                return false;
            }
            return false;
        }

        protected override void OnError(SocketError error)
        {
            Log.Register($"TCP Server Connection to Client({Endpoint}) Encountered an Error : {error}");
        }
    }

    #endregion

    #region Client

    class TCPClient : NetCoreServer.TcpClient
    {
        public TCPClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();

        }

        protected override void OnConnected()
        {
            Log.Register($"TCP Client Connected to Server({Address})");
        }

        protected override void OnDisconnected()
        {
            if (!_stop)
            {
                Thread.Sleep(1000);
                ConnectAsync();
                Log.Register($"Connection To TCP Server({Address}) Disconnected!\r\nTrying to Reconnect");
            }
            else
            {
                Log.Register($"Connection To TCP Server({Address}) Disconnected!");
            }
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);

            if (message.IndexOf("Rejected") >= 0)
            {
                EstablishConnection.ChangeServerStatus();
            }

            Log.Register($"Server : {message}");
        }

        protected override void OnError(SocketError error)
        {
            if (error == SocketError.TimedOut)
                Log.Register($"TCP Connection to Server({Address}) TimedOut");
            else
                Log.Register($"TCP Connection to Server({Address}) Encountered an Error : {error}");
        }

        private bool _stop;
    }

    #endregion
}
