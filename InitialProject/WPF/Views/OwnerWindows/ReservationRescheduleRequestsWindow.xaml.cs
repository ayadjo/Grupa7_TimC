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

namespace InitialProject.WPF.Views.OwnerWindows
{
    /// <summary>
    /// Interaction logic for ReservationRescheduleRequestsWindow.xaml
    /// </summary>
    public partial class ReservationRescheduleRequestsWindow : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<ReservationRescheduleRequest> ReservationRescheduleRequests { get; set; }
        public ReservationRescheduleRequestController _reservationRescheduleRequestsController;

        public ReservationRescheduleRequest SelectedReservationRescheduleRequest { get; set; }

        public RelayCommand RequestHandlingCommand { get; set; }
        public ReservationRescheduleRequestsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            _reservationRescheduleRequestsController = new ReservationRescheduleRequestController();

            ReservationRescheduleRequests = new ObservableCollection<ReservationRescheduleRequest>(_reservationRescheduleRequestsController.GetAllRequestsForHandling());

            RequestHandlingCommand = new RelayCommand(RequestHandlingButton_Click, CanHandle);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Refresh()
        {
            ReservationRescheduleRequests.Clear();
            foreach (ReservationRescheduleRequest request in _reservationRescheduleRequestsController.GetAllRequestsForHandling())
            {
                ReservationRescheduleRequests.Add(request);
            }
        }

        public bool CanHandle(object param)
        {
            return SelectedReservationRescheduleRequest != null;
        }
        private void RequestHandlingButton_Click(object sender)
        {
            
            ReservationRescheduleRequestHandlingWindow ReservationRescheduleRequestHandling = new ReservationRescheduleRequestHandlingWindow(SelectedReservationRescheduleRequest);
            ReservationRescheduleRequestHandling.ShowDialog();

            Refresh();
          
        }
    }
}
