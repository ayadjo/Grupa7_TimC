using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationReservationWindow.xaml
    /// </summary>
    public partial class AccommodationReservationWindow : Window
    {
        private readonly AccommodationReservationRepository accommodationReservationRepository;
        public Accommodation accommodation;
        public int us;
        public User guest;
        public GuestReview guestReview = new GuestReview { Id = -1 };

        bool isAvailable = true;

        public AccommodationReservationWindow(Accommodation a, User user)
        {
            InitializeComponent();
            accommodation = a;
            guest = user;
            accommodationReservationRepository = new AccommodationReservationRepository();
        }

        DateTime start;
        private void StartDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            start = (DateTime)e.AddedItems[0];
        }

        DateTime end;
        private void EndDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            end = (DateTime)e.AddedItems[0];
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            int numberOfDaysForReservation = 0;
            try
            {
                numberOfDaysForReservation = Convert.ToInt32(NumberOfDaysTextBox.Text);
            }
            catch { }
            int numberOfGuests = 0;
            try
            {
                numberOfGuests = Convert.ToInt32(NumberOfGuestsTextBox.Text);
            }
            catch { }

            if (StartDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli pocetni datum!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (EndDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli krajnji datum!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(NumberOfDaysTextBox.Text) || numberOfDaysForReservation == 0)
            {
                MessageBox.Show("Niste uneli broj dana za rezervaciju!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(NumberOfGuestsTextBox.Text) || numberOfGuests == 0)
            {
                MessageBox.Show("Niste uneli broj gostiju koji dolaze!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (numberOfDaysForReservation < accommodation.MinDaysForReservation)
            {
                MessageBox.Show("Uneli ste manje dana nego što je moguće za ovaj smeštaj!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (numberOfGuests > accommodation.MaxGuests)
            {
                MessageBox.Show("Uneli ste više gostiju nego što je moguće za ovaj smeštaj!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foreach (AccommodationReservation reservation in reservations)
                {
                    // Check if the selected dates overlap with the reservation dates
                    if (
                        reservation.Accommodation.Id == accommodation.Id &&
                        ((start >= reservation.Start && start < reservation.End) ||
                        (end > reservation.Start && start <= reservation.End) ||
                        (start < reservation.Start && end > reservation.End))
                        )
                    {
                        isAvailable = false;
                        break;
                    }
                }

                if (isAvailable)
                {
                    //GuestReview guestReview = new GuestReview { Id = -1 };
                    accommodationReservationRepository.AddReservedAccommodations(accommodation, guest, start, end, guestReview);
                    MessageBox.Show("Uspešno ste rezervisali smeštaj!", "Rezervisano!", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Smeštaj je tada zauzet!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }








        public static List<AccommodationReservation> ReadCSV(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            List<AccommodationReservation> reservations = new List<AccommodationReservation>();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                int id = Convert.ToInt32(line[0]);
                Accommodation accommodation = new Accommodation() { Id = Convert.ToInt32(line[1]) };
                User guest = new User() { Id = Convert.ToInt32(line[2]) };
                DateTime start = DateTime.Parse(line[3]);
                DateTime end = DateTime.Parse(line[4]);
                GuestReview guestReview = new GuestReview() { Id = Convert.ToInt32(line[5]) };
                AccommodationReservation reservation = new AccommodationReservation(id, accommodation, guest, start, end, guestReview);
                reservations.Add(reservation);
            }
            reader.Close();
            return reservations;
        }

        List<AccommodationReservation> reservations = ReadCSV("../../../Resources/Data/accommodationReservations.csv");



    }
}
