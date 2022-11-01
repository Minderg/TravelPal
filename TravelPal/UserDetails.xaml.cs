using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        private UserManager uManager;
        private TravelManager tManager;
        private User user;

        public UserDetails(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            this.uManager = uManager;
            this.tManager = tManager;
           
            // Lägger till Länder i comboboxen
            cbUserDetails.ItemsSource = Enum.GetNames(typeof(Countries));

            // Displayar vad usern har för username, password & country
            txtUsername.Content = uManager.SignedInUser.Username;
            txtPassword.Content = uManager.SignedInUser.Password;
            txtCountry.Content = uManager.SignedInUser.Location;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(uManager, tManager);

            travelsWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Hämtar innehållet i textrutorna
            string newUsername = txtNewUsername.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string newcountry = cbUserDetails.Text;
            //Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbUserDetails.Text);

            if(this.uManager.UpdateUserName(user, newUsername) && this.uManager.UpdatePassword(newPassword, confirmPassword))
            {
                // Sätter det till det nya som userna har skrivit
                uManager.SignedInUser.Username = newUsername;
                uManager.SignedInUser.Password = newPassword;
                //uManager.SignedInUser.Location = selectedCountry;

                MessageBox.Show("You have saved you information!");
            }
        }
    }
}
