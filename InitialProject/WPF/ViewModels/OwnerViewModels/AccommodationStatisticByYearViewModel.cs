using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views;
using InitialProject.WPF.Views.OwnerWindows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class AccommodationStatisticByYearViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }

        public ObservableCollection<AccommodationByYearStatisticDto> AccommodationStatistics { get; set; }
        public AccommodationReservationController _accommodationReservationController;

        public Accommodation Accommodation { get; set; }

        private AccommodationByYearStatisticDto _selectedStatistic;
        public AccommodationByYearStatisticDto SelectedStatistic
        {
            get { return _selectedStatistic; }

            set
            {
                _selectedStatistic = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand StatisticsByMonthCommand { get; set; }
        public RelayCommand GeneratePdfReportCommand { get; set; }

        public List<AccommodationByYearStatisticDto> Statistic { get; set; }
        public int BestYear { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public AccommodationStatisticByYearViewModel(Accommodation accommodation)
        {
            Accommodation = accommodation;
            _accommodationReservationController = new AccommodationReservationController();
            AccommodationStatistics = new ObservableCollection<AccommodationByYearStatisticDto>(_accommodationReservationController.GetYearStatisticForAccommodation(Accommodation.Id));
            Statistic = new List<AccommodationByYearStatisticDto>(_accommodationReservationController.GetYearStatisticForAccommodation(Accommodation.Id));

            StatisticsByMonthCommand = new RelayCommand(Execute_StatisticsByMonthCommand, CanExecute_StatisticsByMonthCommand);

            BestYear = _accommodationReservationController.GetBestYearForAccommodation(Accommodation.Id);

            YearStart = AccommodationStatistics.Min(x => x.Year);
            YearEnd = AccommodationStatistics.Max(x => x.Year);

            GeneratePdfReportCommand = new RelayCommand(Execute_GeneratePdfReportCommand);
        }
        public bool CanExecute_StatisticsByMonthCommand(object param)
        {
            return SelectedStatistic != null;
        }

        public void Execute_StatisticsByMonthCommand(object param)
        {
            AccommodationStatisticsByMonth statisticsByMonth = new AccommodationStatisticsByMonth(SelectedStatistic, Accommodation);
            statisticsByMonth.Show();
        }


        private void Execute_GeneratePdfReportCommand(object sender)
        {
            Document document = new Document();

            // Set up the output stream
            string filePath = "statisticki_izvestaj.pdf";
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            // Open the document
            document.Open();

            // Add the title and subtitle
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
            Paragraph title = new Paragraph("Statisticki izvestaj", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph("\n"));
            // Add the accommodation name and location

            Font accommodationFont = FontFactory.GetFont(FontFactory.HELVETICA, 14);
            Paragraph accommodationDetails = new Paragraph();
            accommodationDetails.Alignment = Element.ALIGN_CENTER;
            accommodationDetails.Add(new Chunk(Accommodation.Name , accommodationFont)); // Zamijenite "Naziv smeštaja ovdje" sa stvarnim nazivom smeštaja
            accommodationDetails.Add(new Chunk(" - ", accommodationFont));
            accommodationDetails.Add(new Chunk(Accommodation.Location.Country + ", " + Accommodation.Location.City, accommodationFont)); // Zamijenite "Lokacija smeštaja ovdje" sa stvarnom lokacijom smeštaja
            document.Add(accommodationDetails);

            // Add a separator
            LineSeparator separator = new LineSeparator();
            document.Add(new Chunk(separator));

            // Create the table for company and customer info
            PdfPTable infoTable = new PdfPTable(3);
            infoTable.WidthPercentage = 100;

            // Add company info
            PdfPCell companyCell = new PdfPCell();
            companyCell.Border = Rectangle.NO_BORDER;

            Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            Paragraph companyInfo = new Paragraph();
            companyInfo.Add(new Chunk("Preduzeće:\n", boldFont));
            companyInfo.Add(new Chunk("AccommodationService\n", infoFont));
            companyInfo.Add(new Chunk("Novi Sad, Srbija\n", infoFont));
            companyCell.AddElement(companyInfo);
            infoTable.AddCell(companyCell);

            // Add empty cell for spacing
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(emptyCell);

            // Add customer info
            PdfPCell customerCell = new PdfPCell();
            customerCell.Border = Rectangle.NO_BORDER;
            customerCell.HorizontalAlignment = Element.ALIGN_RIGHT;

            Paragraph customerDetails = new Paragraph();
            customerDetails.Add(new Chunk("Klijent:\n", boldFont));

            // Retrieve the tourist object
            User user = SignInForm.LoggedUser;
            if (user != null)
            {
                // Access the name and email properties of the tourist
                string userName = user.FirstName + " " + user.LastName;

                // Add the tourist name and email to the "Customer details" section
                customerDetails.Add(new Chunk(userName + "\n", infoFont));
            }

            customerDetails.Add(new Chunk("Datum generisanja izvestaja:\n", boldFont));
            customerDetails.Add(new Chunk(DateTime.Now.ToString("dd.MM.yyyy."), infoFont));
            customerCell.AddElement(customerDetails);
            infoTable.AddCell(customerCell);

            // Add the info table to the document
            document.Add(infoTable);
          
            document.Add(new Paragraph("\n"));

            Paragraph paragraph = new Paragraph("Statistički izveštaj za izabrani smeštaj", infoFont);
            document.Add(paragraph);

            // Add two rows of space
            document.Add(new Paragraph("\n"));

            // Create the table
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;

            // Set the column widths
            float[] columnWidths = { 2f, 2f, 2f, 2f, 2f };
            table.SetWidths(columnWidths);

            // Add table headers
            PdfPCell headerCell = new PdfPCell();
            headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            headerCell.Padding = 5;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            headerCell.Phrase = new Phrase("Godina", infoFont);
            table.AddCell(headerCell);

            headerCell.Phrase = new Phrase("Ukupno rezervacija", infoFont);
            table.AddCell(headerCell);

            headerCell.Phrase = new Phrase("Otkazane rezervacije", infoFont);
            table.AddCell(headerCell);

            headerCell.Phrase = new Phrase("Pomerene rezervacije", infoFont);
            table.AddCell(headerCell);

            headerCell.Phrase = new Phrase("Predlozi za renoviranje", infoFont);
            table.AddCell(headerCell);


            // Add tour booking data to the table
            foreach (AccommodationByYearStatisticDto statisticDto in Statistic)
            {
                table.AddCell(new PdfPCell(new Phrase(statisticDto.Year.ToString(), infoFont)));
                table.AddCell(new PdfPCell(new Phrase(statisticDto.ReservationsNum.ToString(), infoFont)));
                table.AddCell(new PdfPCell(new Phrase(statisticDto.CancelledReservationsNum.ToString(), infoFont)));
                table.AddCell(new PdfPCell(new Phrase(statisticDto.RescheduledReservationsNum.ToString(), infoFont)));
                table.AddCell(new PdfPCell(new Phrase(statisticDto.RecommendationForRenovationNum.ToString(), infoFont)));
            }

            // Add the table to the document
            document.Add(table);

            // Add a thank you message
            Paragraph thankYouParagraph = new Paragraph("Hvala Vam što sarađujete sa nama!", infoFont);
            thankYouParagraph.Alignment = Element.ALIGN_RIGHT;
            document.Add(new Paragraph("\n")); // Add some space before the thank you message
            document.Add(thankYouParagraph);

            // Close the document
            document.Close();

            // Open the PDF document with the default application
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}