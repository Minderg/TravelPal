﻿using System;
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

        public UserDetails()
        {
            InitializeComponent();

            // Lägger till Länder i comboboxen

            cbUserDetails.ItemsSource = Enum.GetNames(typeof(Countries));

        }
    }
}
