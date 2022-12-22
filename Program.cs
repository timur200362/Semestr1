using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using INF2course.Controllers;
using INF2course.DAO;

namespace INF2course
{
    public class Program
    {
        private static bool _appIsRunning = true;
        static void Main(string[] args)
        {
            StreamReader SR = new StreamReader("settings.json");
            string open_json = SR.ReadLine();
            SR.Close();
            HttpServer3 server = JsonSerializer.Deserialize<HttpServer3>(open_json);

            server.Init();
            server.Start();
            while (_appIsRunning)
                Handler(Console.ReadLine()?.ToLower(), server);
        }
        static void Handler(string command, HttpServer3 server)
        {
            switch (command)
            {
                case "stop": server.Stop(); break;
                case "restart": server.Stop(); server.Start(); break;
                case "start": server.Start(); break;
                case "status": Console.WriteLine(server.Status.ToString()); break;
                case "exit": _appIsRunning = false; break;
            }
        }
    }
}
