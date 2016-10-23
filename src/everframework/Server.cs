using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace everframework
{
    public class Server
    {
        private static volatile Server instance;
        private static object syncRoot = new Object();

        private WorldManager _worldmanager;

        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Server();
                    }
                }

                return instance;
            }
        }

        private ILogger _logger;
        private bool _running = false;
        public Server()
        {

        }

        public void SetLogger(ILogger logger)
        {
            this._logger = logger;
        }

        public ILogger GetLogger()
        {
            return this._logger;
        }

        public bool IsRunning()
        {
            return this._running;
        }

        public void Start(CancellationToken token)
        {
            if (Server.Instance.IsRunning() == true)
                return;

            GetLogger().LogInformation("Starting Up");
            Server.Instance._worldmanager = new WorldManager(Server.Instance.GetLogger());

            if (!File.Exists("world.xml"))
            {
                // Create a temporary world
                Server.Instance.GetWorldManager().LoadDefaultWorld();
            }
            else
            {
                Server.Instance.GetWorldManager().LoadWorld();
            }

            Server.Instance._running = true;

            Task.Factory.StartNew(() => Server.Instance.MainLoop(token), token);
        }

        public WorldManager GetWorldManager()
        {
            return Server.Instance._worldmanager;
        }

        private void MainLoop(CancellationToken token)
        {
            while (_running == true)
            {
                token.ThrowIfCancellationRequested();
                Tick();
            }
        }

        public void Tick()
        {

        }

        private void Stop()
        {
            GetLogger().LogInformation("Shutting Down");
            Server.Instance._running = false;
        }

        public void CommandReceiver(String command)
        {
            switch(command.Split(' ')[0])
            {
                case "quit":
                    Stop();
                    break;
                default:
                    GetLogger().LogInformation("Unknown Command: " + command.Split(' ')[0]);
                    break;
            }
        }
    }
}
