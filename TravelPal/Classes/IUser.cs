using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
    }
}
