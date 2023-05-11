using InitialProject.Controller;
using InitialProject.Domain.Models;
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
    /// Interaction logic for DeclineReservationRescheduleRequestCommentWindow.xaml
    /// </summary>
    public partial class DeclineReservationRescheduleRequestCommentWindow : Window, INotifyPropertyChanged
    {
        public ReservationRescheduleRequestController _reservationRescheduleRequestController;

        #region NotifyProperties
        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (value != _comment)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        public ReservationRescheduleRequest ReservationRescheduleRequest { get; set; }

        public RelayCommand FinishCommand { get; set; }

        public DeclineReservationRescheduleRequestCommentWindow(ReservationRescheduleRequest reservationRescheduleRequest)
        {
            InitializeComponent();
            this.DataContext = this;

            _reservationRescheduleRequestController = new ReservationRescheduleRequestController();

            ReservationRescheduleRequest = reservationRescheduleRequest;

            FinishCommand = new RelayCommand(AddCommentButton_Click, CanFinish);

            CommentTextBox.Focus();

        }

        public bool CanFinish(object param)
        {
            return true;
        }

        private void AddCommentButton_Click(object sender)
        {

            ReservationRescheduleRequest.Status = Enumerations.RequestStatusType.Declined;
            ReservationRescheduleRequest.Comment = Comment;
            _reservationRescheduleRequestController.Update(ReservationRescheduleRequest);
            Close();
        }
    }
}
