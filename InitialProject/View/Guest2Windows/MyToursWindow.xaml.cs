using InitialProject.Controller;
using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace InitialProject.View.Guest2Windows
{
    /// <summary>
    /// Interaction logic for MyToursWindow.xaml
    /// </summary>
    public partial class MyToursWindow : Window, INotifyPropertyChanged
    { 
        public ObservableCollection<TourEvent> TourEvents { get; set; }

        public TourEventController _tourEventController;

        public TourReservationController _tourReservationController;

        private TourEvent _selectedTourEvent;
        public TourEvent SelectedTourEvent
        {
            get => _selectedTourEvent;
            set
            {
                if (_selectedTourEvent != value)
                {
                    _selectedTourEvent = value;
                    OnPropertyChanged("SelectedTourEvent");
                }
            }
        }
        public MyToursWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _tourEventController = new TourEventController();
            _tourReservationController = new TourReservationController();

            TourEvents = new ObservableCollection<TourEvent>(_tourReservationController.UsersTourEvents(SignInForm.LoggedUser.Id));
        }

        private void TourPoint_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedTourEvent == null)
            {
                return;
            }
            TourPointsWindow tourPointsWindow = new TourPointsWindow(SelectedTourEvent);
            tourPointsWindow.Show();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
