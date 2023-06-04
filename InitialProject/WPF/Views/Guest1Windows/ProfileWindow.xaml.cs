using InitialProject.Controller;
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

namespace InitialProject.WPF.Views.Guest1Windows
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private readonly ForumController _forumController;
        private readonly LocationController _locationController;

        public ObservableCollection<Forum> Forums { get; set; }
        public Forum SelectedForum { get; set; }

        public User guest { get; set; }

        public ProfileWindow(User user)
        {
            InitializeComponent();
            DataContext = this;

            guest = user;

            _forumController = new ForumController();
            _locationController = new LocationController();

            Forums = new ObservableCollection<Forum>(_forumController.GetByAuthorId(guest.Id));

            for (int i = 0; i < Forums.Count; ++i)
            {
                Forums[i].Location = _locationController.GetAll().Find(a => a.Id == Forums[i].Location.Id);

            }
        }

        private void CancelButon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseForumButon_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedForum == null)
            {
                MessageBox.Show("Prvo morate odabrati forum!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Forum forum = new Forum() { Id = SelectedForum.Id, Location = SelectedForum.Location, Author = SelectedForum.Author, IsOpen = false};
                _forumController.Update(forum);
                MessageBox.Show("Uspešno ste zatvorili izabrani forum!", "Zatvoremno!", MessageBoxButton.OK);
            }
        }
    }
}
