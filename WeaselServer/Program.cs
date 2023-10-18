using System;
using WeaselServer.CommandHandler;

namespace WeaselServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Starting the server
            Console.WriteLine("Starting the Weasel-Server!");

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
