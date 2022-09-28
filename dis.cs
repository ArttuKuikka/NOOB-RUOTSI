using DiscordRPC.Logging;
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOOBRUOTSI
{
    public class dis
    {
        public DiscordRpcClient client;

        //Called when your application first starts.
        //For example, just before your main loop, on OnEnable for unity.
        public void Initialize()
        {
            /*
            Create a Discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("1024765162005221376");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            //client.OnPresenceUpdate += (sender, e) =>
            //{
            //    Console.WriteLine("Received Update! {0}", e.Presence);
            //};

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "Mikä on {sana}",
                State = "sana {nyt}/{maara}",
                Assets = new Assets()
                {
                    LargeImageKey = "image_large",
                    LargeImageText = "Noob ruotsi",
                    SmallImageKey = "image_small"
                }

            });
        }
    }
}
