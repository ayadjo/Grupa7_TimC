using InitialProject.Controller;
using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using InitialProject.Domain.Models;
using InitialProject.WPF.ViewModels.Guest2ViewModels;
using InitialProject.WPF.Views.Guest2Windows;
using System.Reflection.Metadata;
using System.Printing;
using System.IO;
using System.Xml.Linq;
using System.Windows.Xps.Packaging;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Fonts;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using System.Drawing;
using InitialProject.WPF.Views.OwnerWindows;
using iTextSharp.text;

namespace InitialProject.WPF.Views.Guest2Window
{
    /// <summary>
    /// Interaction logic for TourReservationWindow.xaml
    /// </summary>
    public partial class TourReservationWindow : Window, INotifyPropertyChanged
    {

        public TourReservationController _tourReservationController;
        public TourEventController _tourEventController;
        public VoucherController _voucherController;

        private string _availableSpotsText { get; set; }
        private int _availableSpots { get; set; }


        private TourEvent _selectedTourEvent;

        public string AvailableSpotsText
        {
            get => _availableSpotsText;
            set
            {
                if (_availableSpotsText != value)
                {
                    _availableSpotsText = value;
                    OnPropertyChanged("AvailableSpotsText");
                }
            }
        }

        public int AvailableSpots
        {
            get => _availableSpots;
            set
            {
                if (_availableSpots != value)
                {
                    _availableSpots = value;
                    OnPropertyChanged("AvailableSpots");
                }
            }
        }


        public TourEvent SelectedTourEvent
        {
            get => _selectedTourEvent;
            set
            {
                if (_selectedTourEvent != value)
                {
                    _selectedTourEvent = value;
                    OnPropertyChanged("SelectedTourEvent");
                }
            }
        }

        private TourPoint _tourPoint;

        public TourPoint TourPoint
        {
            get => _tourPoint;
            set
            {
                if (_tourPoint != value)
                {
                    _tourPoint = value;
                    OnPropertyChanged("TourPoint");
                }
            }
        }

        private Voucher _selectedVoucher;

        public Voucher SelectedVoucher
        {
            get => _selectedVoucher;
            set
            {
                if (_selectedVoucher != value)
                {
                    _selectedVoucher = value;
                    OnPropertyChanged("SelectedVoucher");
                }
            }
        }
        public int NumberOfPeople { get; set; }

        public TourPoint TourPointWhenGuestCame { get; set; }


        public ObservableCollection<TourEvent> TourEvents { get; set; }
        public ObservableCollection<Voucher> Vouchers { get; set; }

        public TourReservationWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = this;

            _tourReservationController = new TourReservationController();
            _tourEventController = new TourEventController();
            _voucherController = new VoucherController();

            TourEvents = new ObservableCollection<TourEvent>(_tourEventController.GetTourEventsNotPassedForTour(tour));
            Vouchers = new ObservableCollection<Voucher>(_voucherController.VoucherForUser(SignInForm.LoggedUser));

            numberOfPeopleTextBox.Focus();

        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {

            if (AvailableSpots >= NumberOfPeople)
            {

                User user = SignInForm.LoggedUser;
                TourReservation existingTourReservation = _tourReservationController.GetTourReservationForTourEventAndUser(SelectedTourEvent.Id, user.Id);

                if (existingTourReservation != null)
                {
                    MessageBox.Show("Vec ste rezervisali ovu turu!");
                }
                else
                {
                    TourPointWhenGuestCame = new TourPoint { Id = -1 };
                    TourReservation tourReservation = new TourReservation(-1, NumberOfPeople, SelectedTourEvent, user, TourPointWhenGuestCame, SelectedVoucher, false);
                    _tourReservationController.Save(tourReservation);

                    if (SelectedVoucher != null)
                    {
                        Vouchers.Remove(SelectedVoucher);
                        SelectedVoucher = null;
                    }

                    MessageBox.Show("Uspesno ste rezervisali!");
                }
                this.Close();

            }
            else
            {
                MessageBox.Show("Nema dovoljno mesta!");
            }

            return;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTours(List<TourEvent> tourEvents)
        {
            TourEvents.Clear();
            foreach (TourEvent tourEvent in tourEvents)
            {
                TourEvents.Add(tourEvent);
            }
        }

        private void Check_Availability_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTourEvent == null)
            {
                return;
            }

            int reservedSpots = _tourEventController.CheckAvailability(SelectedTourEvent);
            AvailableSpots = SelectedTourEvent.Tour.MaxGuests - reservedSpots;

            if (AvailableSpots < NumberOfPeople)
            {
                AvailableSpotsText = "Nema dovoljno mesta";
                if (SelectedTourEvent == null)
                {
                    return;
                }
                List<TourEvent> tourEventsForLocation = _tourEventController.GetAvailableTourEventsForLocation(SelectedTourEvent.Tour.Location, NumberOfPeople);
                RefreshTours(tourEventsForLocation);
            }
            else
            {
                AvailableSpotsText = "Broj slobodnih:";
            }
        }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Suggest_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTourEvent == null)
            {
                return;
            }
            List<TourEvent> tourEventsForLocation = _tourEventController.GetAvailableTourEventsForLocation(SelectedTourEvent.Tour.Location, NumberOfPeople);
            RefreshTours(tourEventsForLocation);
        }
        

        private void VoucherReports_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PDF document
            using (PdfDocument document = new PdfDocument())
            {
                // Add a page to the document
                PdfPage page = document.AddPage();

                // Create a graphics object for drawing on the page
                XGraphics gfx = XGraphics.FromPdfPage(page);



                // Set up the font
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
                XFont titleFont = new XFont("Arial", 16, XFontStyle.Bold, options);
                XFont subtitleFont = new XFont("Arial", 12, XFontStyle.Bold, options);
                XFont contentFont = new XFont("Arial", 10, XFontStyle.Regular, options);

                // Set up the font and color
                XFont titleFont1 = new XFont("Arial", 16, XFontStyle.Bold);
                XSolidBrush titleBackgroundBrush = new XSolidBrush(XColor.FromArgb(223, 251, 255)); 

                // Get the voucher data
                List<Voucher> vouchers = _voucherController.VoucherForUser(SignInForm.LoggedUser);

                // Set up the page layout
                XRect pageBounds = new XRect(40, 40, page.Width - 80, page.Height - 80);
                XRect titleBounds = new XRect(pageBounds.Left, pageBounds.Top, pageBounds.Width, 30);
                XRect tableBounds = new XRect(pageBounds.Left, pageBounds.Top + 35, pageBounds.Width, pageBounds.Height - 35);
                


                // Draw the title with background color
                gfx.DrawRectangle(titleBackgroundBrush, titleBounds);
                gfx.DrawString("Voucher Reports", titleFont1, XBrushes.Black, titleBounds, XStringFormats.Center);


                // Add a line after the title
                XPoint lineStart = new XPoint(titleBounds.Left, titleBounds.Bottom + 2);
                XPoint lineEnd = new XPoint(titleBounds.Right, titleBounds.Bottom + 2);
                gfx.DrawLine(XPens.Black, lineStart, lineEnd);


                XRect userDetailsBounds = new XRect(pageBounds.Left + 2, lineEnd.Y + 5, 100, 20);
                gfx.DrawString("User details", subtitleFont, XBrushes.Black, userDetailsBounds, XStringFormats.TopLeft);

               

                // Retrieve the first name and last name of the user
                string firstName = SignInForm.LoggedUser.FirstName;
                string lastName = SignInForm.LoggedUser.LastName;
                string email = SignInForm.LoggedUser.Email;

                // Format the user details
                string userFirstnameLastName = $"{firstName} {lastName}";
                string userEmail = $"{email}";

                // Draw the user details
                XRect userDetailsTextBounds = new XRect(userDetailsBounds.Left, userDetailsBounds.Bottom + 2, 200, 12);
                gfx.DrawString(userFirstnameLastName, contentFont, XBrushes.Black, userDetailsTextBounds, XStringFormats.TopLeft);

                // Calculate the Y position for the next line (user age)
                //double nextLineYPos1 = userDetailsTextBounds.Bottom + 5;

                XRect userEmailTextBounds = new XRect(userDetailsBounds.Left, userDetailsTextBounds.Bottom + 2, 200, 50);
                gfx.DrawString(userEmail, contentFont, XBrushes.Black, userEmailTextBounds, XStringFormats.TopLeft);

                // Adjust nextLineYPos for the next line
                //nextLineYPos1 += 20;

                
                XRect reportMadeBounds = new XRect(userDetailsTextBounds.Right + 220, userDetailsBounds.Top, 100, 20);
                gfx.DrawString("Report made on", subtitleFont, XBrushes.Black, reportMadeBounds, XStringFormats.TopLeft);

                // Add the date when the report is made
                string reportDate = DateTime.Now.ToString("dd-MM-yyyy");
                XRect dateBounds = new XRect(userDetailsTextBounds.Right + 260, userDetailsTextBounds.Top, 100, 20);
                gfx.DrawString(reportDate, contentFont, XBrushes.Black, dateBounds, XStringFormats.TopLeft);


                // Declare and initialize headerXPos and columnWidth variables
                int headerXPos = (int)tableBounds.Left;
                int headerYPos = (int)userDetailsBounds.Bottom + 20; // Adjust the value as needed
                int columnWidth = (int)tableBounds.Width / 4;

                // Calculate the Y position for the next line
                double paragraphSpace = 40;
                double nextLineYPos = userDetailsBounds.Bottom + paragraphSpace;
 

                // Adjust nextLineYPos to add paragraph spacing
                nextLineYPos += paragraphSpace;



                // Define the border style
                XPen tableBorderPen = new XPen(XColor.FromArgb(223, 251, 255), 1);

                // Draw the table border
                gfx.DrawRectangle(tableBorderPen, tableBounds);

                int tableWidth = columnWidth * 2;

                // Center the table horizontally
                int headerXPos1 = (int)(pageBounds.Width - tableWidth) / 2 + 30;

                // Draw the table headers
                gfx.DrawString("Name", subtitleFont, XBrushes.Black, new XRect(headerXPos1, nextLineYPos, columnWidth, 20), XStringFormats.Center);
                gfx.DrawString("Expiration Date", subtitleFont, XBrushes.Black, new XRect(headerXPos1 + columnWidth, nextLineYPos, columnWidth, 20), XStringFormats.Center);

                // Calculate the table height based on the number of voucher data rows
                int tableHeight = (vouchers.Count + 1) * 20; // +1 for the headers

                // Define the border color
                XColor borderColor = XColor.FromArgb(223, 251, 255);

                // Draw the table border
                XRect tableBorder = new XRect(headerXPos1, nextLineYPos, columnWidth * 2, tableHeight);
                gfx.DrawRectangle(new XPen(borderColor), tableBorder);

                // Draw the voucher data
                int dataYPos = (int)nextLineYPos + 20;
                foreach (Voucher voucher in vouchers)
                {
                    gfx.DrawString(voucher.Name, contentFont, XBrushes.Black, new XRect(headerXPos1, dataYPos, columnWidth, 20), XStringFormats.Center);
                    gfx.DrawString(voucher.ExpirationDate.ToString("dd-MM-yyyy"), contentFont, XBrushes.Black, new XRect(headerXPos1 + columnWidth, dataYPos, columnWidth, 20), XStringFormats.Center);
                    
                    

                    dataYPos += 20;
                    
                }


                // Save the PDF document
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\voucher_report.pdf";
                document.Save(filePath);

                // Open the PDF document with the default application
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }


    }
}
    
