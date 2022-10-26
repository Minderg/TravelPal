using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser SingedInUser { get; set; }

        // Add user
        public bool AddUser(string username, string password, Countries country)
        {
            if (ValidateUserName(username))
            {
                User user = new(username, password, country);
                users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveUser(string username, string password, Countries country)
        {
            // Tar bort en user (Admin bara)
        }
        public bool UpdateUserName(string username, string password, Countries country)
        {
            // Om usern vill byta namn
            return true;
        }

        private bool ValidateUserName(string username)
        {
            // Bekräfta userns name
            // Kolla om usernamet är upptaget,
            // Om INTE upptaget - returnera true
            // Om upptaget - returnera false

            //if(username == ValidateUserName(username){

            //}
            return true;
        }

        public bool SignInUser(string username, string password)
        {
            // Signar in usern


            return true;
        }

        public List<IUser> GetAllUsers()
        {
            return users;
        }

    }
}
