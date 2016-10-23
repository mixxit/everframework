using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using everframework;
using System.Threading;

namespace evergame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILoggerFactory loggerfactory = new LoggerFactory()
            .AddConsole()
            .AddDebug();

            ILogger logger = loggerfactory.CreateLogger<Program>();
            Server.Instance.SetLogger(logger);
            CancellationTokenSource token = new CancellationTokenSource();
            Server.Instance.Start(token.Token);

            while(Server.Instance.IsRunning())
            {
                String input = Console.ReadLine();
                Server.Instance.CommandReceiver(input);
            }
        }
    }
}
