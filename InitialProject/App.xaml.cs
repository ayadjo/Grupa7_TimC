﻿using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AccommodationRepository.GetInstance();
            LocationRepository.GetInstance();
            TourRepository.GetInstance();
            TourEventRepository.GetInstance();
            TourPointRepository.GetInstance(); 
            ImageRepository.GetInstance();
            

            AccommodationRepository.GetInstance().BindAccomodationLocation();
            TourRepository.GetInstance().BindTourLocation();
            TourPointRepository.GetInstance().BindTourPointTour();
            TourEventRepository.GetInstance().BindTourEventTour();
            ImageRepository.GetInstance().BindImageResource();
            

        }
    }
}
