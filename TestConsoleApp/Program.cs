using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoWorldUnity3D;
using System.Threading;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GoWorld.RegisterEntity(typeof(Account));
            GoWorld.RegisterEntity(typeof(Player));
            GoWorld.RegisterEntity(typeof(Monster));
            GoWorld.Connect("127.0.0.1", 14001);
            Debug(GoWorldUnity3D.GoWorld.GameClient + " created.");

            while (true) {
                GoWorldUnity3D.GoWorld.Tick();
                Thread.Sleep(100);
            }
        }

        private static void Debug(string msg, params object[] args)
        {
            Console.WriteLine(String.Format("DEBUG - Program - " + msg, args));
        }
    }
}
