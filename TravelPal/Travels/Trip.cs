using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps;

namespace TravelPal.Travels
{
    public class Trip : Travel
    {
        public Type TripType { get; set; }

        public Trip()
        {

        }

        //public string GetInfo()
        //{
        //    // Ta reda på vad usern har valt för alternativ för resan
        //}
    }
}
