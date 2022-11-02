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

        // Returnar AddTravel
        public Travel AddTravel(string destination, Countries countries, int travellers, TripTypes tripTypes)
        {

            return AddTravel(destination, countries, travellers, tripTypes);
        }

        // Checkar om man väljer Trip (Work/Leisure)
        public Travel CreateTrip(string destination, Countries country, int travellers, TripTypes tripTypes)
        {
            Trip trip = new(travellers, destination, country, tripTypes);

            travels.Add(trip);
            return trip;
        }

        // Checkar om man Vacation (All Incluvise)
        public Travel CreateVacation(string destination, Countries country, int travellers, bool allInclusive)
        {
            Vacation vacation = new(allInclusive, destination, country, travellers);

            travels.Add(vacation);
            return vacation;
        }
    }
}
