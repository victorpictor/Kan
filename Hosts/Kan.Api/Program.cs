using System;
using Microsoft.Owin.Hosting;

namespace Kan.Api
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<ApiStartup>("http://localhost:9000"))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}