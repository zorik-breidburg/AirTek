using System;
using System.Collections.Generic;

namespace SpeedyAir
{
    class Flight
    {
        public int Number { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }

        public Flight(int number, string departure, string arrival, int day)
        {
            Number = number;
            Departure = departure;
            Arrival = arrival;
            Day = day;
        }

        public override string ToString()
        {
            return $"Flight: {Number}, departure: {Departure}, arrival: {Arrival}, day: {Day}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>
            {
                new Flight(1, "YUL", "YYZ", 1),
                new Flight(2, "YUL", "YYC", 1),
                new Flight(3, "YUL", "YVR", 1),
                new Flight(4, "YUL", "YYZ", 2),
                new Flight(5, "YUL", "YYC", 2),
                new Flight(6, "YUL", "YVR", 2)
            };

            Console.WriteLine("Loaded flight schedule:");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
    }
}
