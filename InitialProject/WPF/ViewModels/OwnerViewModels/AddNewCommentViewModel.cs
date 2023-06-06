using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class AddNewCommentViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }
        public Forum SelectedForum { get; set; }
        public CommentController _commentController;
        public ForumController _forumController;
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (value != _text)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public AddNewCommentViewModel(Forum forum)
        {
            SelectedForum = forum;
            _commentController = new CommentController();
            _forumController = new ForumController();
            FinishCommand = new RelayCommand(Execute_FinishCommand);
            CloseCommand = new RelayCommand(Execute_CloseCommand);
        }

        

        public void Execute_FinishCommand(object param)
        {
            Comment comment = new Comment() { Text = Text, Author = SignInForm.LoggedUser, ForumId = SelectedForum.Id, ReportsNumber = 0, Role = Enumerations.UserType.Owner };
            _commentController.Save(comment);
            SelectedForum.Comments.Add(comment);
            _forumController.Update(SelectedForum);
            Close();
            
        }

        public void Execute_CloseCommand(object param)
        {
            Close();
        }

    }
}
