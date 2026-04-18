using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp
{
    public class Trip
    {
        public string Destination { get; set; }
        public string Company { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int SeatsAvailable { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
