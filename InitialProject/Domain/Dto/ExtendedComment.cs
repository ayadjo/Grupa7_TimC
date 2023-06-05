using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Dto
{
    public class ExtendedComment: Comment, INotifyPropertyChanged
    {
        private bool isGuestOnLocation;

        public bool IsGuestOnLocation
        {
            get { return isGuestOnLocation; }
            set
            {
                if (isGuestOnLocation != value)
                {
                    isGuestOnLocation = value;
                    OnPropertyChanged(nameof(IsGuestOnLocation));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
