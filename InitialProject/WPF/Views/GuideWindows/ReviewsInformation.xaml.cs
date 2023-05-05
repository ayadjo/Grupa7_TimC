using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
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

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for ReviewsInformation.xaml
    /// </summary>
    public partial class ReviewsInformation : Window
    {
        public GuideReviewController _guideReviewController;
        public GuideReview CurrentUser { get; set; }
        public ObservableCollection<ReviewDto> Reviews { get; set; }
        public ObservableCollection<GuideReview> GuideReviews { get; set; }

        public ReviewDto SelectedReview { get; set; }
        public ReviewsInformation(GuideReview user)
        {
            InitializeComponent();
            this.DataContext = this;
            CurrentUser = user;
            _guideReviewController = new GuideReviewController();
            GuideReviews = new ObservableCollection<GuideReview>(_guideReviewController.GetAllGuideReviews(SignInForm.LoggedUser.Id, CurrentUser.Reservation.Guest.Id));

            Reviews = new ObservableCollection<ReviewDto>();
            foreach(GuideReview guideReview in GuideReviews)
            {
                ReviewDto guideReviewDto = new ReviewDto(guideReview);
                Reviews.Add(guideReviewDto);
            }
        }

        

        private void IsValid_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReview != null)
            {

                if (SelectedReview.Validity == false)
                {

                    SelectedReview.Validity = true;
                    GuideReview guideReview = _guideReviewController.Get(SelectedReview.Id);
                    guideReview.Validity = true;
                    _guideReviewController.Update(guideReview);
                    MessageBox.Show("Uspesno ste prijavili recenziju!");
                    

                }

            }
        }

        private void ReviewsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
