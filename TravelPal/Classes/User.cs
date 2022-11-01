using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Classes
{
    public class User : IUser
    {
        public List<Travel> usersTravels = new();
        public List<Travel> users = new();

        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public User(string username, string password, Countries country)
        {
            Username = username;
            Password = password;
            Location = country;
        }
    }
}
