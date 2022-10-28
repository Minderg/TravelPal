using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;
        private User user;
        private TravelManager travelManager;
        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();

            // Visa vilken usern som är in inloggad

            this.userManager = userManager;
            // Fråga Albin
            if(this.userManager.SignedInUser is User)
            {
                this.user = this.userManager.SignedInUser as User;
                lbSeeUser.Content = $"{this.user.Username}";
            }
            //else if (this.userManager.SignedInUser is Admin)
            //{
            //    // Så man ser admin 
            //}
        }

        // Poppar upp en ruta så man kan läsa hur man använder appen
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Travel Pal! The new app on the market to book any flight that you want. If you wanna add a destination," +
                " just click add and fill in the information that comes up, very simple and easy to use." +
                " Whenever you have added a destination, you will see the information at the Travel Information, and the best thing is" +
                " if you changed you mind on a trip, just click the destination that you want to remove and just click the remove button!" +
                " Ain´t harder then that.");
        }

        // Signar ut usern och återkommer till Sign In fönstret
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();

            Close();
            mainWindow.Show();
        }

        // Lägger till och sparar en ny resa
        private void btnAddDestination_Click(object sender, RoutedEventArgs e)
        {
            AddTravel addTravel = new(travelManager, userManager);

            addTravel.Show();
        }
    }
}
