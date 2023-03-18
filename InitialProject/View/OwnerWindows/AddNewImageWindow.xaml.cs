using InitialProject.Controller;
using InitialProject.Enumerations;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AddNewImageWindow.xaml
    /// </summary>
    public partial class AddNewImageWindow : Window, INotifyPropertyChanged
    {
        public ImageController _imageController;

        #region NotifyProperties
        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                if (value != _url)
                {
                    _url = value;
                    OnPropertyChanged("Url");
                }
            }
        }
        private ImageResource _resource;
        private string _description;
        public string Description
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
        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;


        public ImageResource Resource { get; set; }

       
        public AddNewImageWindow( ImageResource resource)
        {
            InitializeComponent();
            this.DataContext = this;
            _imageController = new ImageController();
            Resource = resource;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Image image = new Image(-1, Url, -1, Description, Resource);
            _imageController.Save(image);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddMoreImages_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
