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
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravel.xaml
    /// </summary>
    public partial class AddTravel : Window
    {
        private UserManager userManager;
        public AddTravel()
        {
            InitializeComponent();

            // Lägger till Länder i comboboxen
            string[] countries = Enum.GetNames(typeof(Countries));

            cbAddCountry.ItemsSource = countries;

            this.userManager = userManager;

            // Lägger till Work/Leisure i combobox

            string[] tripTypes = Enum.GetNames(typeof(TripTypes));

            cbChoose.ItemsSource = tripTypes;

            this.userManager = userManager;

        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager);

            travelsWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
