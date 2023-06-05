using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        

        public ForumCommentsOverviewViewModel(Forum forum)
        {
            _commentController = new CommentController();
            SelectedForum = forum;

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

                
    }
}