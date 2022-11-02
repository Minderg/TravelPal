using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager uManager;
        private User user;
        private TravelManager tManager;
        public List<Travel> travels = new();
      
        public TravelsWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();

            // Visa vilken usern som är in inloggad om det är en user eller Admin

            this.uManager = uManager;
            this.tManager = tManager;

            if(this.uManager.SignedInUser is User)
            {
                this.user = this.uManager.SignedInUser as User;
                lbSeeUser.Content = $"Welcome {this.user.Username}";

                User signedInUser = uManager.SignedInUser as User;

                foreach (var travel in signedInUser.usersTravels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvTravelInformation.Items.Add(item);
                }
            }
            else if(this.uManager.SignedInUser is Admin)
            {
                lbSeeUser.Content = $"Welcome Admin";

                foreach (var travel in tManager.travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvTravelInformation.Items.Add(item);
                }
            }
        }

        // Poppar upp en ruta så man kan läsa hur man använder appen
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Travel Pal! The new app on the market to Add any flight that you want. If you wanna add a destination," +
                " just click add and fill in the information that comes up, very simple and easy to use." +
                " Whenever you have added a destination, you will see the information at the Travel Information, and the best thing is" +
                " if you changed you mind on a trip, just click the destination that you want to remove and just click the remove button!" +
                " Ain´t harder then that.");
        }

        // Signar ut usern och återkommer till Sign In fönstret
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(uManager, tManager);

            mainWindow.Show();
            Close();
        }

        // Lägger till och sparar en ny resa
        private void btnAddDestination_Click(object sender, RoutedEventArgs e)
        {
            AddTravel addTravel = new(tManager, uManager);
            addTravel.Show();
            Close();    
        }

        // Möjlig gör om man klickar på en resa så ska man kunna se mer detaljer om den
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvTravelInformation.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelsDetailsWindow tDetailsWindow = new TravelsDetailsWindow(uManager, tManager, selectedTravel);

                tDetailsWindow.Show();
                Close();
            }
            else
            {

                MessageBox.Show("Please select a travel");

            }
        }
     
        // Kan ta bort vald resa
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemToRemove = lvTravelInformation.SelectedItem as ListViewItem;

            lvTravelInformation.Items.Remove(itemToRemove);

            Travel selectedTravel = itemToRemove.Tag as Travel;

            tManager.travels.Remove(selectedTravel);

            User signedInUser = uManager.SignedInUser as User;
            signedInUser.usersTravels.Remove(selectedTravel);
        }

        // Ser till att man får upp UserDetails fönstret
        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetails userDetails = new(uManager, tManager);

            userDetails.Show();
            Close();
        }
    }
}
