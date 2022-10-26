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
using TravelPal.Enums;
using TravelPal.IUser;

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
            // Signar in usern

            MessageBox.Show("Please fill in the information");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Ska poppa upp en ny WPF, där user kan registrera sig

            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();
            Close();
        }
    }
}
