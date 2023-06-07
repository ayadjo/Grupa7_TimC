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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
