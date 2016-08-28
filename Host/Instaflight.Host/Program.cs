using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Instaflight_thing;
using Microsoft.Owin.Hosting;

namespace Instaflight.Host
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine($"Started OWIN at: {baseAddress}");
            Console.ReadLine();
        }
    }
}
