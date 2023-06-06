using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.OwnerWindows;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class ForumCommentsOverviewViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }
        private ObservableCollection<ExtendedComment> _comments;
        public ObservableCollection<ExtendedComment> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }


        public CommentController _commentController;
        public ForumController _forumController;

        private Forum _selectedForum;
        public Forum SelectedForum
        {
            get => _selectedForum;
            set
            {
                _selectedForum = value;
                LoadComments();
                OnPropertyChanged();
            }
        }

        private ExtendedComment _selectedComment;
        public ExtendedComment SelectedComment
        {
            get => _selectedComment;
            set
            {
                _selectedComment = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand AddNewCommentCommand { get; set; }
        
        public RelayCommand ReportCommentCommand { get; set; }
        public ForumCommentsOverviewViewModel(Forum forum)
        {
            _commentController = new CommentController();
            _forumController = new ForumController();
            SelectedForum = forum;
            CloseCommand = new RelayCommand(Execute_CloseCommand);
            AddNewCommentCommand = new RelayCommand(Execute_AddNewCommentCommand, CanExecute_AddNewCommentCommand);
            ReportCommentCommand = new RelayCommand(Execute_ReportCommentCommand, CanExecute_ReportCommentCommand);
        }

        public bool CanExecute_ReportCommentCommand(object param)
        {
            return SelectedComment != null;
        }

        public void Execute_ReportCommentCommand(object param)
        {
            Comment comment = _commentController.Get(SelectedComment.Id);
            comment.ReportsNumber++;
            _commentController.Update(comment);
            Refresh();
        }

        private void LoadComments()
        {
            List<Comment> loadedComments = _commentController.GetByForum(SelectedForum.Id);

            Comments = new ObservableCollection<ExtendedComment>();

            foreach (Comment comment in loadedComments)
            {
                ExtendedComment ExtendedComment = new ExtendedComment
                {

                    Id = comment.Id,
                    Text = comment.Text,
                    Author = comment.Author,
                    Role = comment.Role,
                    ForumId = comment.ForumId,
                    ReportsNumber = comment.ReportsNumber,
                    IsGuestOnLocation = _commentController.CheckGuestOnLocation(comment, SelectedForum)
                };
                Comments.Add(ExtendedComment);
            }

        }
        public void Refresh()
        {
            Comments.Clear();
            List<Comment> loadedComments = _commentController.GetByForum(SelectedForum.Id);
            foreach (Comment comment in loadedComments)
            {
                ExtendedComment ExtendedComment = new ExtendedComment
                {

                    Id = comment.Id,
                    Text = comment.Text,
                    Author = comment.Author,
                    Role = comment.Role,
                    ForumId = comment.ForumId,
                    ReportsNumber = comment.ReportsNumber,
                    IsGuestOnLocation = _commentController.CheckGuestOnLocation(comment, SelectedForum)
                };
                Comments.Add(ExtendedComment);
            }

        }
        public void Execute_CloseCommand(object param)
        {
            Close();
        }

        public bool CanExecute_AddNewCommentCommand(object param)
        {
            return true;
        }

        public void Execute_AddNewCommentCommand(object param)
        {
            if (_forumController.CheckIfOwnerHasAccommodationOnLocation(SelectedForum))
            {
                AddNewCommentWindow AddNewComment = new AddNewCommentWindow(SelectedForum);
                AddNewComment.ShowDialog();
                Refresh();
            }
            else
            {
                MessageBox.Show("Nije moguce dodati komentar.");
                
            }
            
        }


    }
}