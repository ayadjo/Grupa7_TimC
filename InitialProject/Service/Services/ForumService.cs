using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Enumerations;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject.Service.Services
{
    public class ForumService
    {
        private IForumRepository _forumRepository;

        private ICommentRepository _commentRepository;

        private AccommodationRepository _accommodationRepository;

        public ForumService()
        {
            _forumRepository = Injector.Injector.CreateInstance<IForumRepository>();

            _commentRepository = Injector.Injector.CreateInstance<ICommentRepository>();

            _accommodationRepository = AccommodationRepository.GetInstance();
        }

        public List<Forum> GetAll()
        {
            return _forumRepository.GetAll();
        }

        public Forum Get(int id)
        {
            return _forumRepository.Get(id);
        }
        public Forum Save(Forum forum)
        {
            return _forumRepository.Save(forum);
        }
        public Forum Update(Forum forum)
        {
            return _forumRepository.Update(forum);
        }
        public void Delete(Forum forum)
        {
            _forumRepository.Delete(forum);
        }

        public Forum SaveForumComment(Forum forum)
        {
            return _forumRepository.SaveForumComment(forum);
        }

        public Boolean AvailableForum(Forum forum)
        {
            List<Forum> forums = GetAll();
            foreach (Forum forumFor in forums)
            {
                if (forum.Location.City == forumFor.Location.City)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckIfOwnerHasAccommodationOnLocation(Forum forum)
        {
            List<Accommodation> accommodations = _accommodationRepository.GetByOwner(SignInForm.LoggedUser.Id);
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Location == forum.Location)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
