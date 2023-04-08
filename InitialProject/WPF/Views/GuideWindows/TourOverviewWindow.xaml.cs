using InitialProject.Controller;
using InitialProject.Domain.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace InitialProject.View.GuideWindows
{
    /// <summary>
    /// Interaction logic for TourOverviewWindow.xaml
    /// </summary>
    public partial class TourOverviewWindow : Window
    {
        public ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour { get; set; }
        public TourController _tourController;
        
        public TourOverviewWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _tourController = new TourController();

            Tours = new ObservableCollection<Tour>(_tourController.GetAll());
        }

        private void CreateToursButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTour createTour = new CreateTour();
            createTour.Show();
            Close();
            Update();
        }

        private void UpdateToursList()
        {

            foreach (var tour in _tourController.GetAll())
            {
                Tours.Add(tour);
            }
        }

        public void Update()
        {
            UpdateToursList();
        }
    }
}
