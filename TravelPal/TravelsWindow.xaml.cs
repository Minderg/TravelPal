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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();

        }

        // Poppar upp en ruta så man kan läsa hur man använder appen
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Travel Pal! The new app on the market to book any flight that you want. If you wanna add a destination," +
                " just click add and fill in the information that comes up, very simple and easy to use." +
                " Whenever you have added a destination, you will see the information at the Travel Information, and the best thing is" +
                " if you changed you mind on a trip, just click the destination that you want to remove and just click the remove button!" +
                " Ain´t harder then that.");
        }

        // Signar ut usern och återkommer till Sign In fönstret
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();

            Close();
            mainWindow.Show();
        }
    }
}
