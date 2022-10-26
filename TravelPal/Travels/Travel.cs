using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travellers { get; set; }

        public Travel()
        {
            // Props
            // Fråga Albin
        }

        //public virtual string GetInfo()
        //{
        //    // Hämta information angående resa
        //}
    }
}
