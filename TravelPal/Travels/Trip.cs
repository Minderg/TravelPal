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
        public List<Travel> userTravels = new(); // Kanske anväder denna 

        public TripTypes TripType { get; set; }

        public Trip(int travellers, string destination, Countries country, TripTypes tripTypes) : base(destination, country, travellers)
        {

            TripType = tripTypes;
        }

        public override string GetInfo() // ska vara en override
        {
            // Ta reda på vad usern har valt för alternativ för resan
            return $"Country | {base.Country}";
        }

        public override string GetTravelType()
        {
            return "Trip";
        }
    }
}
