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
using TravelPal.Enums;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
         

        private UserManager userManager;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            // Lägger till Länder i comboboxen
            string[] countries = Enum.GetNames(typeof(Countries));

            cbRegister.ItemsSource = countries;

            this.userManager = userManager;


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrerar en användare
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string country = cbRegister.Text;

            // Omvandlar Country till en string
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

            if(this.userManager.AddUser(username, password, selectedCountry))
            {
                MainWindow mainWindow = new(this.userManager);
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
