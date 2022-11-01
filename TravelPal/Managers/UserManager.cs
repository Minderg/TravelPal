using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Managers
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser SignedInUser { get; set; }  
        public List<Travel> travels = new();
        public List<Travel> userTravels = new(); // Kanske ska ha denna
        private TravelManager tManager;

        public UserManager(TravelManager tManager)
        {
            AddAdminUser();
            AddGandalf();

            Vacation vacation = new(true, "Turkey", Enums.Countries.Turkey, 4);
            tManager.userTravels.Add(vacation);

        }

        // Add an user to the list
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
            // Tar bort resor som users har lagt till(Admin bara)
        }

        // Kollar längden på username & om det är ett tomt username
        public bool UpdateUserName(IUser users, string username)
        {
           
            if(username.Length < 3)
            {
                MessageBox.Show("Need a longer Username!");
                return false;
            }
            else if(username == null)
            {
                MessageBox.Show("Need to fill in username");
                return false;
            }
            else if(ValidateUserName(username) == false)
            {
                return false;
            }

            return true;
        }

        // Kollar längden på lösenordet & om det är ett tomt lösenord
        public bool UpdatePassword(string confirmPassword, string password)
        {
            if(password.Length < 5)
            {
                MessageBox.Show("Need a longer Password");
                return false;
            }
            else if(confirmPassword == null)
            {
                MessageBox.Show("Need to fill in password");
                return false;
            }
            return true;
        }

        // Kollar om usern redan finns med
        private bool ValidateUserName(string username)
        {
            foreach (IUser user in users)
            {
                if (user.Username == username)
                {
                    return false;
                }
            }
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

        // Lägger till en Admin
        public void AddAdminUser()
        {
            Admin admin = new("admin", "password");
            
            users.Add(admin);     
        }

        public void AddGandalf()
        {
            User user = new("Gandalf", "password", Enums.Countries.Sweden);
            users.Add(user);
        }
    }
}
