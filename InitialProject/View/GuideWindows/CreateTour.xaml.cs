using InitialProject.Model;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for CreateTour.xaml
    /// </summary>
    public partial class CreateTour : Window, INotifyPropertyChanged
    {

        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public CreateTour()
        {
            InitializeComponent();
            this.DataContext = this;
            Tour Tour = new Tour();
        }

        #region NotifyProperties
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (value != _selectedCountry)
                {
                    _selectedCountry = value;
                    OnPropertyChanged("SelectedCountry");
                }
            }
        }
        private string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (value != _selectedCity)
                {
                    _selectedCity = value;
                    OnPropertyChanged("SelectedCity");
                }
            }
        }
        
        private int _description;
        public int Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private int _language;
        public int Language
        {
            get => _language;
            set
            {
                if (value != _language)
                {
                    _language = value;
                    OnPropertyChanged("Language");
                }
            }
        }

        private int _maxGuests;
        public int MaxGuests
        {
            get => _maxGuests;
            set
            {
                if (value != _maxGuests)
                {
                    _maxGuests = value;
                    OnPropertyChanged("MaxGuests");
                }
            }
        }

        /*private int _tourPoints;
        public int TourPoints
        {
            get => _tourPoints;
            set
            {
                if (value != _tourPoints)
                {
                    _tourPoints = value;
                    OnPropertyChanged("TourPoints");
                }
            }
        }*/

        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }





        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(MaxGuestTxt.Text);
            value++;
            MaxGuestTxt.Text = value.ToString();
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(MaxGuestTxt.Text);
            value--;
            MaxGuestTxt.Text = value.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CityComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LanguageComboBox_LostFocus(object sender, RoutedEventArgs e) 
        { 
        
        
        }

        private void AddTourEvents_Click(object sender, RoutedEventArgs e)
        {


        }

    }
}
