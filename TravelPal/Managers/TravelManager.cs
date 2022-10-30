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

        public void CreateTrip(string destination, Countries countries, int travellers, TripTypes work)
        {
            Trip trip = new(travellers, destination, countries, work);

            travels.Add(trip);
        }

        //public void CreateVacation(string destination, Countries countries, int travellers, bool vacation)
        //{
        //    Vacation vacation = new(bool allInclusive);
        //}

        public void RemoveTravel(Travel travel)
        {

        }
    }
}
