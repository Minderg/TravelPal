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
        public List<Travel> travels = new();

        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public User(string username, string password, Countries country)
        {
            Username = username;
            Password = password;
            Location = country;
        }
        
        // Kolla om du behöver denna för att skapa Gandalf usern
        //public User(string username, string password)
        //{
        //    Username = username;
        //    Password = password;
        //}
    }
}
