using System;
using System.Net;
using System.Threading;

namespace InternetConnectivityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (ConnectionIsPossible())
            {
                Thread.Sleep(10000);
            }

            while (true)
            {
                Console.WriteLine("Google not pingable!! Connection Failed!!!");
                System.Media.SystemSounds.Exclamation.Play();
                Thread.Sleep(500);
            }
        }

        private static bool ConnectionIsPossible()
        {
            bool connectionIsPossible;
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://google.com"))
                {
                    connectionIsPossible = true;
                }
            }
            catch
            {
                connectionIsPossible = false;
            }
            return connectionIsPossible;
        }
    }
}
