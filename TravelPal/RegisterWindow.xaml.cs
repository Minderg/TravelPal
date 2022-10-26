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
using TravelPal.IUser;

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

            this.userManager = userManager;

            // Fixa så att alla länder syns och inte string[] array
            string[] countries = Enum.GetNames(typeof(Countries));

            foreach (string country in countries)
            {
                cbRegister.Items.Add(countries);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string country = cbRegister.Text;

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
