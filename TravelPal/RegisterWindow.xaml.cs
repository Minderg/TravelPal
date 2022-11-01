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
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager uManager;
        private TravelManager tManager;
        public RegisterWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();

            // Lägger till Länder i comboboxen
            string[] countries = Enum.GetNames(typeof(Countries));

            cbRegister.ItemsSource = countries;

            this.uManager = uManager;
            this.tManager = tManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrerar en användare
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string country = cbRegister.Text;

            // Omvandlar Country till en string
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

            // Kollar om usern redan finns registrerad
            // Kolla om jag kan använda mig om .Length också
            if (username.Count() == 0 || password.Count() == 0 || country.Count() == 0)
            {
                MessageBox.Show("Username is invalid or already used!");
            }
            else if (this.uManager.AddUser(username, password, selectedCountry))
            {
                MainWindow mainWindow = new(uManager, tManager);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Username is invalid or already used!");
            }
        }
    }
}
