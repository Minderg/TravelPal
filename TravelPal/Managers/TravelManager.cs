using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        public Travel AddTravel(string destination, Countries countries, int travellers, TripTypes tripTypes)
        {

            return AddTravel(destination, countries, travellers, tripTypes);
        }

        public void CreateTrip(string destination, Countries countries, int travellers, TripTypes tripTypes)
        {
            Trip trip = new(travellers, destination, countries, tripTypes);

            travels.Add(trip);
        }

        public void RemoveTravel(Travel travel)
        {

        }
    }
}
