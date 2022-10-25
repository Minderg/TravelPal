using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Travels
{
    public class Vacation
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive)
        {
            AllInclusive = allInclusive;
        }

        //public string GetInfo()
        //{
        //    // Ska ta reda på vad usern har valt för något
        //    return AllInclusive;
        //}
    }
}
