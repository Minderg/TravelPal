using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private UserManager uManager;
        public TravelManager tManager;
        private string SelectedTravelType;
        public List<Travel> travels = new();


        // Får ut allting i comboboxes/checkboxes
        public AddTravel(TravelManager tManager, UserManager uManager)
        {
            InitializeComponent();

            this.tManager = tManager;
            this.uManager = uManager;

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

        // Savea det usern har skrivit in och skicka det vidare till Travelswindows listview
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDestination.Text))
                {

 
                bool isAllInclusive = false;

                string country = cbAddCountry.SelectedItem as string;
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                string destination = txtDestination.Text; 

                int travellers = Convert.ToInt32(txtTravelers.Text);

                //Checkar vad man har checkat in checkboxen / All Inclusive eller inte
                if (cbChoose.SelectedIndex == 0)
                {
                    if ((bool)xbAllInclusive.IsChecked)
                    {
                        isAllInclusive = true;
                    }

                    Travel travel = tManager.CreateVacation(destination, selectedCountry, travellers, isAllInclusive);
                    User user = uManager.SignedInUser as User;
                    user.usersTravels.Add(travel);

                    uManager.SignedInUser = user;
                }

                //Checkar om vad man har checkat in checkboxen
                else if (cbChoose.SelectedIndex == 1)
                {

                    string trip = cbTripType.SelectedItem as string;
                    TripTypes selectedTrip = (TripTypes)Enum.Parse(typeof(TripTypes), trip);
                    Travel travel = tManager.CreateTrip(destination, selectedCountry, travellers, selectedTrip);

                    User user = uManager.SignedInUser as User;
                    user.usersTravels.Add(travel);

                    uManager.SignedInUser = user;
                }
                }
                else
                {
                    throw new NullReferenceException();
                }
                TravelsWindow travelsWindow = new(uManager, tManager);
                travelsWindow.Show();
                Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Need to choose a country");
            }
            catch (FormatException)
            {
                MessageBox.Show("Need to enter numbers of travelers");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Need to fill in all information");
            }
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

        // Kommer till TravelsWindow fönstret
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(uManager, tManager);

            travelsWindow.Show();
            Close();
        }
    }
}
