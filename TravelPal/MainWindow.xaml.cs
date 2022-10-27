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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();

            this.userManager = new();

        }

        public MainWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Signar in usern som har lagt in till Listan IUser
            List<IUser> users = userManager.GetAllUsers(); 

            string username = txtUsername.Text;
            string password = pswPassword.Password;

            bool userFound = false;

            foreach (IUser user in users)
            {
                if(user.Username == username && user.Password == password)
                {
                    userFound = true;
                    TravelsWindow travelsWindow = new();
                    travelsWindow.Show();
                    this.Close();
                }
            }
            // Kollar om usern har skrivit in fel
            if(!userFound)
            {
                MessageBox.Show("The username or password was incorrect!");
            }

           

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // RegisterWindow dyker upp så usern kan registrera sig
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();
            Close();
        }
    }
}
