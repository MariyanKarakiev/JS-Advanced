﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models
{
    public class TripViewModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime ConvertedDate { get; internal set; }
    }
}
