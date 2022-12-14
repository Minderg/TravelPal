using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return $"Country | {Country}";
        }

        public override string GetTravelType()
        {
            return "Vacation";
        }

        public override string GetTravelInfo()
        {
            if (AllInclusive)
            {
                return "AllInclusive";
            }
            else
            {
                return "Not AllInclusive";
            }
            
        }
    }
}
