using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.Managers
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            AddAdminUser();
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
        public bool UpdateUserName(string username, string password, Countries country)
        {
            // Om usern vill byta namn
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
            //User resa = new("Gandalf", "password");

            //users.Add(resa);
        }

    }
}
