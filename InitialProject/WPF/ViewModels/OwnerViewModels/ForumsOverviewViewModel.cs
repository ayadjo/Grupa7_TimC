using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class ForumsOverviewViewModel: ViewModelBase
    {
        public ObservableCollection<Forum> Forums { get; set; }
        public ForumController _forumController;

        public RelayCommand SeeCommentsCommand { get; set; }

        private Forum _selectedForum;
        public Forum SelectedForum
        {
            get => _selectedForum;
            set
            {
                if (value != _selectedForum)
                {
                    _selectedForum = value;
                    OnPropertyChanged();
                }
            }
        }

        public ForumsOverviewViewModel()
        {
            _forumController = new ForumController();
            Forums = new ObservableCollection<Forum>(_forumController.GetAll());
            SeeCommentsCommand = new RelayCommand(Execute_SeeCommentsCommand, CanExecute_SeeCommentsCommand);
            SelectedForum = Forums.ElementAt(0);
        }

        public bool CanExecute_SeeCommentsCommand(object param)
        {
            return SelectedForum != null;
        }

        public void Execute_SeeCommentsCommand(object param)
        {
            ForumCommentsOverviewWindow Comments = new ForumCommentsOverviewWindow(SelectedForum);
            Comments.Show();
        }
        
    }
}
