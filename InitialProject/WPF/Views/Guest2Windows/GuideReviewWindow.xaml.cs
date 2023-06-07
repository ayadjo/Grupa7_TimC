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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using InitialProject.WPF.ViewModels.Guest2ViewModels;
using InitialProject.WPF.ViewModels;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for GuideReviewWindow.xaml
    /// </summary>
 
    public partial class GuideReviewWindow : Window
    {

        public GuideReviewViewModel guideReviewViewModel;

        public GuideReviewWindow(TourReservation SelectedTourReservation)
        {
            InitializeComponent();
            //navigationService = NavigationService.GetNavigationService(this);
            guideReviewViewModel = new GuideReviewViewModel(SelectedTourReservation);
            this.DataContext = guideReviewViewModel;

            if (DataContext is IClose vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
        
    }
}
