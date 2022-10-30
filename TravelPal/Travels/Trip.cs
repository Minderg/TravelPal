using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    public class Trip : Travel
    {
        public List<Travel> travels = new();

        public TripTypes TripType { get; set; }
        public int Travellers { get; set; }
        public string Destination { get; set; }
        public Countries Country { get; set; }

        public Trip(int travellers, string destination, Countries country, TripTypes tripTypes)
        {
            Travellers = travellers;
            Destination = destination;
            Country = country;
            TripType = tripTypes;
        }

        public override string GetInfo() // ska vara en override
        {
            // Ta reda på vad usern har valt för alternativ för resan
            return $"Country | {base.Country}";
        }
    }
}
