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
    /// Interaction logic for TourPointsWindow.xaml
    /// </summary>
    public partial class TourPointsWindow : Window
    {
        public ObservableCollection<TourPoint> TourPoints { get; set; }

        public TourPointController _tourPointController { get; set; }
        public TourEventController _tourEventController { get; set; }

        
        public TourEvent SelectedTourEvent { get; set; }
        

        public TourPointsWindow(TourEvent selectedTourEvent)
        {
            InitializeComponent();
            this.DataContext = this;

            _tourPointController = new TourPointController();
            _tourEventController = new TourEventController();

            SelectedTourEvent = selectedTourEvent;

            TourPoints = new ObservableCollection<TourPoint>(SelectedTourEvent.Tour.TourPoints);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
