using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.IUser
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser SingedInUser { get; set; }

        // Fråga Albin om alla dessa, varför dem blir röda???????????????????????

        public bool AddUser(IUser)
        {
            // Lägger till en user
        }
        public void RemoveUser(IUser)
        {
            // Tar bort en user (Admin bara)
        }
        public bool UpdateUserName(IUser, string users)
        {
            // Om usern vill byta namn
            return true;
        }

        private bool ValidateUserName(string username)
        {
            // Bekräfta userns name
            return true;
        }

        public bool SignInUser(string username, string password)
        {
            // Signar in usern
            return true;
        }

    }
}
