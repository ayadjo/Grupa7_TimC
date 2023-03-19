using InitialProject.Forms;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.View;
using InitialProject.View.OwnerView;
using InitialProject.View.OwnerWindows;
using InitialProject.View.Guest2Window;
using InitialProject.View.GuideWindows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = UserRepository.GetInstance();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByUsername(Username);

            

            if (user != null)
            {
                if (user.Password == txtPassword.Password)
                {
                    //CommentsOverview commentsOverview = new CommentsOverview(user);
                    //commentsOverview.Show();
                    if (ComboBoxRoles.SelectedIndex == -1)
                    {
                        MessageBox.Show("You didn't select the role!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (ComboBoxRoles.SelectedIndex == 0)
                    {
                        // OwnerWindow
                        MessageBox.Show("Owner Window!");

                    }
                    else if (ComboBoxRoles.SelectedIndex == 1)
                    {
                        GuideMainWindow  guideMainWindow = new GuideMainWindow();
                        guideMainWindow.Show(); 
                        MessageBox.Show("Guide Window!");
                    }
                    else if (ComboBoxRoles.SelectedIndex == 2)
                    {
                        // Guest1Window.Show();
                        MessageBox.Show("Guest1 Window!");
                    }
                    else if (ComboBoxRoles.SelectedIndex == 3)
                    {
                        ToursOverviewWindow toursOverview = new ToursOverviewWindow();
                        toursOverview.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
            
        }
   }  
}
