using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
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

        // Kommer tillbaka till TravelsWindow
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(uManager, tManager);

            travelsWindow.Show();
            Close();
        }
        
        // När du klickar på spara så ändras all information som man har skrivit in
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Hämtar innehållet i textrutorna
                string newUsername = txtNewUsername.Text;
                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                

                // Gör så att man måste skriva in rätt password för att komma vidare
                if (this.uManager.UpdateUserName(user, newUsername) && this.uManager.UpdatePassword(newPassword, confirmPassword))
                {
                    // Sätter det till det nya som userna har skrivit
                    
                    string newcountry = cbUserDetails.Text;
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), newcountry);
                    uManager.SignedInUser.Username = newUsername;
                    uManager.SignedInUser.Password = newPassword;
                    uManager.SignedInUser.Location = selectedCountry;

                    txtCountry.Content = uManager.SignedInUser.Location;
                    MessageBox.Show("You have saved you information!");
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Need a full registration to continue");
            }      
        }
    }
}
