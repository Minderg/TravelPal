using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal.Travels
{
    public class Travel
    {
        public List<Travel> travels = new();
        //public List<Travel> userTravels = new(); // Kanske ha denna 
        public List<IUser> users = new();


        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travellers { get; set; }

        public Travel(string destination, Countries country, int travellers)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
        }

        public virtual string GetInfo()
        {
            // Hämta information angående resa
            return $"User {users} | Country | {Country}";
        }

        public virtual string GetTravelType()
        {
            return "TravelType";
        }

        public virtual string GetTravelInfo()
        {
            return "TravelType";
        }
    } 
}
