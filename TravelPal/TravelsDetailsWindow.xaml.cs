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
using TravelPal.Managers;
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsDetailsWindow.xaml
    /// </summary>
    public partial class TravelsDetailsWindow : Window
    {
        private UserManager uManager;
        private TravelManager tManager;

        // Får ut all information om en resa när man klickar på den i Travelswindow
        public TravelsDetailsWindow(UserManager uManager, TravelManager tManager, Travel travel)
        {
            InitializeComponent();
            this.uManager = uManager;
            this.tManager = tManager;

            txtCountry.Text = travel.Country.ToString();
            txtDestination.Text = travel.Destination;
            txtTravelers.Text = travel.Travellers.ToString();
            txtTravelType.Text = travel.GetTravelType();
            txtTravelInfo.Text = travel.GetTravelInfo();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(uManager, tManager);

            travelsWindow.Show();
            Close();
        }
    }
}
