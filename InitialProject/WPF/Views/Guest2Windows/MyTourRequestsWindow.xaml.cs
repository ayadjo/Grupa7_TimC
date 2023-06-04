using InitialProject.Domain.Models;
using InitialProject.WPF.ViewModels;
using InitialProject.WPF.ViewModels.Guest2ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for MyTourRequestsWindow.xaml
    /// </summary>
    public partial class MyTourRequestsWindow : UserControl
    {
        public MyTourRequestsViewModel myTourRequestsViewModel;
        public NavigationService NavigationService { get; set; }


        private ComplexTourRequest _selectedComplexTourRequest;

        public ComplexTourRequest SelectedComplexTourRequest
        {
            get => _selectedComplexTourRequest;
            set
            {
                if (_selectedComplexTourRequest != value)
                {
                    _selectedComplexTourRequest = value;
                    OnPropertyChanged("SelectedComplexTourRequest");
                }
            }
        }

        public MyTourRequestsWindow()
        {
            InitializeComponent();
            myTourRequestsViewModel = new MyTourRequestsViewModel(NavigationService);
            this.DataContext = myTourRequestsViewModel;          
        }

       

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            CreateTourRequestViewModel createTourRequestViewModel = new CreateTourRequestViewModel(this.NavigationService);
            CreateTourRequestWindow createTourRequestWindow = new CreateTourRequestWindow();
            createTourRequestWindow.DataContext = createTourRequestViewModel;  //??
            this.NavigationService.Navigate(createTourRequestWindow);
        }

        
        
        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            TourRequestStatisticsWindow tourRequestStatisticsWindow = new TourRequestStatisticsWindow();
            tourRequestStatisticsWindow.Show();
        }

        private void CreateComplexTourRequest_Click(object sender, RoutedEventArgs e)
        {
            CreateComplexTourRequestWindow createComplexTourRequestWindow = new CreateComplexTourRequestWindow();
            createComplexTourRequestWindow.Show();
        }

        private void ViewComplexTourRequest_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedComplexTourRequest != null)
            {
                PartsOfRequestWindow partsOfRequestWindow = new PartsOfRequestWindow(SelectedComplexTourRequest);
                partsOfRequestWindow.Show();
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
