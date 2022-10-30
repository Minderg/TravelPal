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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager uManager;
        private TravelManager tManager = new();

        public MainWindow()
        {
            InitializeComponent();

            this.uManager = new();

        }

        public MainWindow(UserManager uManager)
        {
            InitializeComponent();

            this.uManager = uManager;
        }

        // Signar in usern som har lagt in till Listan IUser
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            List<IUser> users = uManager.GetAllUsers(); 

            string username = txtUsername.Text;
            string password = pswPassword.Password;

            bool userFound = false;

            foreach (IUser user in users)
            {
                if(user.Username == username && user.Password == password)
                {
                    userFound = true;
                    uManager.SignedInUser = user;
                    TravelsWindow travelsWindow = new(uManager, tManager);
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

        // RegisterWindow dyker upp så usern kan registrera sig
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(uManager);

            registerWindow.Show();
            Close();
        }
    }
}
