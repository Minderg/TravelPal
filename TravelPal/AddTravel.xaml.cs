using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravel.xaml
    /// </summary>
    public partial class AddTravel : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        private string SelectedTravelType;
        private string addInformation;
        
        // Får ut allting i comboboxes/checkboxes
        public AddTravel(TravelManager travelManager, UserManager userManager)
        {
            InitializeComponent();

            // Lägger till Länder i comboboxen
            string[] countries = Enum.GetNames(typeof(Countries));

            cbAddCountry.ItemsSource = countries;

            this.userManager = userManager;

            // Lägger till Vaction/Trip i combobox

            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));

            cbChoose.ItemsSource = travelTypes;

            this.userManager = userManager;

            // Lägger till Work/Leisure i combobox
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));

            cbTripType.ItemsSource = tripTypes;

            this.userManager = userManager;


        }

        // Kommer till TravelsWindow fönstret
        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager);

            travelsWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager);
            // Savea det usern har skrivit in och skicka det vidare till Travelswindows listview

            //string country = cbAddCountry.Text;
            //string username = txtDestination.Text;
            //int travelers = Convert.ToInt32(txtTravelers.Text);
            //string choose = cbChoose.Text;

            travelsWindow.Show();
        }

        // Så man kan välja All Inclusive eller Work/Leisure
        private void cbChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedTravelType = cbChoose.SelectedItem as string;

            if(SelectedTravelType == "Trip")
            {
                cbTripType.Visibility = Visibility.Visible;
                xbAllInclusive.Visibility = Visibility.Hidden;
            }
            else
            {
                cbTripType.Visibility = Visibility.Hidden;
                xbAllInclusive.Visibility = Visibility.Visible;
            }
        }
    }
}
