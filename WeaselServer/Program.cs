using System;
using WeaselServer.CommandHandler;
using WeaselServer.CommandHandler.RestAPI;
using WeaselServer.ConyeverBelt;

namespace WeaselServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Starting the server
            Console.WriteLine("Starting the Weasel-Server V0.00!");
            Console.WriteLine("© Fabian Granig");
            Console.WriteLine("https://github.com/Fabianshrewd/Weasel-Server");

            Console.WriteLine();

            Console.WriteLine("Starting GET-Requests Handler...");
            GetRequests.StartReuests();
            Console.WriteLine("Starting Conveyer Belt...");
            K_ConyeverBelt.StartConveyerBelt();
            Console.WriteLine("GET-Request Handler started.");

            //Accept unlimited commands from the user
            string command = String.Empty;
            while(command != "exit")
            {
                //Read next command
                Console.Write("> ");
                command = Console.ReadLine();

                //Pass the command to the ConsoleQueryWorker
                ConsoleQueryWorker.PickHandler(command);
            }
        }
    }
}