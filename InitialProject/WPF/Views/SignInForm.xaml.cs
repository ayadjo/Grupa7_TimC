using InitialProject.Controller;
using InitialProject.Repositories;
using InitialProject.WPF.Views.OwnerWindows;
using InitialProject.WPF.Views.GuideWindows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.Guest1Windows;

using InitialProject.Enumerations;
using System.Collections.Generic;
using InitialProject.WPF.Views.Guest2Windows;
using InitialProject.Commands;
using InitialProject.Service.Services;

namespace InitialProject.WPF.Views;

/// <summary>
/// Interaction logic for SignInForm.xaml
/// </summary>
public partial class SignInForm : Window
{

    private readonly UserRepository _repository;

    public AccommodationReservationController _accommodationReservationController;
    public NotificationController _notificationController;
    public TourRequestAcceptedNotificationController _tourRequestAcceptedNotificationController;
    public NotificationForRequestController _notificationForRequestController;

    private static User loggedUser;

    public static User LoggedUser
    {
        get => loggedUser;
        
    }

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

    public RelayCommand SignInCommand { get; set; }
    public SignInForm()
    {
        InitializeComponent();
        DataContext = this;
        UsernameTextBox.Focus();
        _repository = UserRepository.GetInstance();

        _accommodationReservationController = new AccommodationReservationController();
        _notificationController = new NotificationController();
        _tourRequestAcceptedNotificationController = new TourRequestAcceptedNotificationController();
        _notificationForRequestController = new NotificationForRequestController();

        SignInCommand = new RelayCommand(SignIn);

        UsernameTextBox.Focus();
    }

    private void SignIn(object sender)
    {
        User user = _repository.GetByUsername(Username);


        if (user != null)
        {
            if (user.Password == txtPassword.Password)
            {
                loggedUser = user;
                if (user.Type == UserType.Owner)
                {
                    int NumberOfGuestsWithoutReview = _accommodationReservationController.FindNumberOfGuestsWithoutReview();
                    MainWindow OwnerMainWindow = new MainWindow();
                    OwnerMainWindow.Show();
                    if (NumberOfGuestsWithoutReview > 0)
                    {
                        GuestsWithoutReviewNotificationWindow Notification = new GuestsWithoutReviewNotificationWindow();
                        Notification.Show();
                    }
                    Close();
                }
                else if (user.Type == UserType.Guide)
                {
                    GuideUIWindow guideMainWindow = new GuideUIWindow();
                    guideMainWindow.Show();
                    this.Close();

                }
                else if (user.Type == UserType.Guest1)
                {
                    Guest1MainWindow guest1MainWindow = new Guest1MainWindow(user);
                    guest1MainWindow.Show();
                }
                else if (user.Type == UserType.Guest2)
                {          
                    List<Notification> notifications = _notificationController.GetNotificationForUser(loggedUser.Id);
                    foreach (Notification notification in notifications)
                    {
                        
                        string tourName = notification.TourReservation.TourEvent.Tour.Name;
                        MessageBoxResult result = MessageBox.Show(this, "You have been added to " + tourName);
                        
                    }

                    List<TourRequestAcceptedNotification> tourRequestAcceptedNotifications = _tourRequestAcceptedNotificationController.GetNotificationForUser(loggedUser.Id);
                    foreach (TourRequestAcceptedNotification tourRequestAcceptedNotification in tourRequestAcceptedNotifications)
                    {

                        string tourRequestName = tourRequestAcceptedNotification.TourRequest.Name;
                        MessageBoxResult result = MessageBox.Show(this, "Your request for" + tourRequestName + " tour is accepted!");

                    }


                    /*List<NotificationForRequest> notificationsForRequest = _notificationForRequestController.GetNotificationForUser(loggedUser.Id);

                    foreach (NotificationForRequest notification in notificationsForRequest)
                    {

                        string requestLocation = notification.TourRequest.Location.City + "(" + notification.TourRequest.Location.City + ")";
                        MessageBoxResult result = MessageBox.Show(this, "Vas zahtev je prihvacen - " + requestLocation);

                    }*/

                    Guest2MainWindow guest2MainWindow = new Guest2MainWindow();
                    guest2MainWindow.Show();
                    this.Close();
                    
                    return;
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
