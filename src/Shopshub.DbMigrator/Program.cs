using Microsoft.Extensions.Hosting;
using System;

namespace Shopshub.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args);
    }
}
