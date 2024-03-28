
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load orders from JSON file
            JObject orders = JObject.Parse(System.IO.File.ReadAllText(@"coding-assigment-orders.json"));

            // Define flight schedule
            Dictionary<string, List<string>> flightSchedule = new Dictionary<string, List<string>>
            {
                { "YYZ", new List<string>() },
                { "YYC", new List<string>() },
                { "YVR", new List<string>() }
            };

            // Schedule orders on flights
            foreach (var order in orders)
            {
                string orderId = order.Key;
                string destination = (string)order.Value["destination"];

                bool scheduled = false;
                foreach (var flight in flightSchedule)
                {
                    if (flight.Value.Count < 20 && flight.Key == destination)
                    {
                        flight.Value.Add(orderId);
                        Console.WriteLine($"order: {orderId}, flightNumber: {flight.Key}, departure: YUL, arrival: {flight.Key}, day: {GetFlightDay(flight.Key)}");
                        scheduled = true;
                        break;
                    }
                }

                if (!scheduled)
                {
                    Console.WriteLine($"order: {orderId}, flightNumber: not scheduled");
                }
            }
        }

        static int GetFlightDay(string destination)
        {
            // Hardcoded flight days for simplicity
            return destination switch
            {
                "YYZ" => 1,
                "YYC" => 1,
                "YVR" => 2,
                _ => 0,
            };
        }
    }
}
