using System;

namespace HelloWorld
{
    public class Eventek
    {
        public Eventek()
        {
            Server server = new Server();
            Client c1 = new Client("Józsi");
            Client c2 = new Client("Béla");
            Client c3 = new Client("Tomi");
            server.Connect(c1);
            server.Connect(c2);
            server.Disconnect(c1);
            server.Connect(c3);
        }
    }

    class ServerEventArgs : EventArgs
    {
        public ServerEventArgs(string message)
            : base()
        {
            Message = message;
        }
        public string Message { get; set; }
    }

    class Server
    {
        public delegate void ServerEvent(object sender, ServerEventArgs e);
        public event ServerEvent ServerChange;
        public void Connect(Client client)
        {
            ServerChange += client.ServerMessageHandler;
            OnServerChange(string.Format("Felhasználó <{0}> csatlakozott!", client.Name));
        }
        public void Disconnect(Client client)
        {
            OnServerChange(string.Format("Felhasználó <{0}> kilépett!", client.Name));
            ServerChange -= client.ServerMessageHandler;
        }
        protected void OnServerChange(string message)
        {
            ServerChange?.Invoke(this, new ServerEventArgs(message));
        }
    }

    class Client
    {
        public Client(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public void ServerMessageHandler(object sender, ServerEventArgs e)
        {
            Console.WriteLine("{0} üzenetet kapott: {1}", Name, e.Message);
        }
    }

}
