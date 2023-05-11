using InitialProject.Controller;
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
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.OwnerWindows
{
    /// <summary>
    /// Interaction logic for GuestsWithoutReviewNotificationWindow.xaml
    /// </summary>
    public partial class GuestsWithoutReviewNotificationWindow : Window, INotifyPropertyChanged
    {
        public AccommodationReservationController _accommodationReservationController;

        public event PropertyChangedEventHandler? PropertyChanged;

        private int _numberOfGuestsWithoutReview;
        public int NumberOfGuestsWithoutReview
        {
            get => _numberOfGuestsWithoutReview;
            set
            {
                if (value != _numberOfGuestsWithoutReview)
                {
                    _numberOfGuestsWithoutReview = value;
                    OnPropertyChanged("NumberOfGuestsWithoutReview");
                }
            }
        }

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public RelayCommand CloseCommand { get; set; }
        public GuestsWithoutReviewNotificationWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _accommodationReservationController = new AccommodationReservationController();
            NumberOfGuestsWithoutReview = _accommodationReservationController.FindNumberOfGuestsWithoutReview();

            CloseCommand = new RelayCommand(CancelButton_Click);
        }

        private void CancelButton_Click(object sender)
        {
            Close();
        }

    }
}
