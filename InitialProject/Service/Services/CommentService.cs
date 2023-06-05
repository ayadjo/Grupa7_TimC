using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class CommentService
    {
        private ICommentRepository _commentRepository;
        private AccommodationReservationRepository _accommodationRepository;
        public CommentService()
        {
            _commentRepository = Injector.Injector.CreateInstance<ICommentRepository>();
            _accommodationRepository = AccommodationReservationRepository.GetInstance();
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }
        public Comment Save(Comment comment)
        {
            return _commentRepository.Save(comment);
        }
        public Comment Update(Comment comment)
        {
            return _commentRepository.Update(comment);
        }
        public void Delete(Comment comment)
        {
            _commentRepository.Delete(comment);
        }

        public List<Comment> GetByForum(int forumId)
        {
            return _commentRepository.GetByForum(forumId);
        }


        public bool CheckGuestOnLocation(Comment comment, Forum forum)
        {
            List<AccommodationReservation> reservations = _accommodationRepository.GetAll();
            foreach(AccommodationReservation reservation in reservations)
            {
                if(reservation.Guest.Id == comment.Author.Id && reservation.IsCancelled == false && comment.ForumId == forum.Id && reservation.Accommodation.Location == forum.Location)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
