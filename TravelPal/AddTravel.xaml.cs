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
        public TravelManager travelManager;
        private string SelectedTravelType;
        
        // Får ut allting i comboboxes/checkboxes
        public AddTravel(TravelManager tManager, UserManager userManager)
        {
            InitializeComponent();

            this.travelManager = tManager;
            this.userManager = userManager;

            // Lägger till Länder i comboboxen
            string[] countries = Enum.GetNames(typeof(Countries));

            cbAddCountry.ItemsSource = countries;

            // Lägger till Vaction/Trip i combobox

            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));

            cbChoose.ItemsSource = travelTypes;

            // Lägger till Work/Leisure i combobox
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));

            cbTripType.ItemsSource = tripTypes;



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
            // Savea det usern har skrivit in och skicka det vidare till Travelswindows listview

            string country = cbAddCountry.SelectedItem as string;
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country); // Omvandlar Country till en string


            // Kolla varför den kraschar här!!!!
            string trip = cbChoose.SelectedItem as string;
            TripTypes selectedTrip = (TripTypes)Enum.Parse(typeof(TripTypes), trip); // Kollar vad man väljer för alternativ för resan
           
            string destination = txtDestination.Text; // Skriver in vart man åker
            int travellers = Convert.ToInt32(txtTravelers.Text); // Skriver in hur många som ska åka

            try
            {
                bool vacationType = false;

                if(trip == "Trip")
                {
                    vacationType = true;
                }
                
                travelManager.CreateTrip(destination, selectedCountry, travellers, selectedTrip);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TravelsWindow travelsWindow = new(userManager);
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
