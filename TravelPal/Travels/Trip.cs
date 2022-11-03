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

        public TripTypes TripType { get; set; }

        public Trip(int travellers, string destination, Countries country, TripTypes tripTypes) : base(destination, country, travellers)
        {

            TripType = tripTypes;
        }

        public override string GetInfo() 
        {
            return $"Country | {base.Country}";
        }

        public override string GetTravelType()
        {
            return "Trip";
        }
        public override string GetTravelInfo()
        {
            return $"{TripType}";
        }
    }
}
