﻿using InitialProject.Forms;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.View;
using InitialProject.View.OwnerView;
using InitialProject.View.OwnerWindows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = UserRepository.GetInstance();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {

            OwnerMainWindow OwnerMainWindow = new OwnerMainWindow();
            OwnerMainWindow.Show();
            //AccommodationsOverview accommodationsOverview = new AccommodationsOverview();
            //accommodationsOverview.Show();
            Close();

        }
   }  
}
