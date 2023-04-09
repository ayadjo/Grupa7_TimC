using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.View.OwnerView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InitialProject.WPF.View.OwnerWindows
{
    /// <summary>
    /// Interaction logic for AccommodationOverviewWindow.xaml
    /// </summary>
    public partial class AccommodationOverviewWindow : Window
    {

        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public AccommodationController _accommodationController;
        public AccommodationOverviewWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _accommodationController = new AccommodationController();

            Accommodations = new ObservableCollection<Accommodation>(_accommodationController.GetAll());
        }

        private void RegistenNewAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewAccommodation NewAccommodation = new RegisterNewAccommodation();
            NewAccommodation.Show();
            Close();
            //Update();
        }
        //mislim da je ovo bespotrebno
        /*private void UpdateAccommodationsList()
        {
        
            foreach (var accommodation in _accommodationController.GetAll())
            {
                Accommodations.Add(accommodation);
            }
        }

        public void Update()
        {
            UpdateAccommodationsList();
        }*/
    }
}
