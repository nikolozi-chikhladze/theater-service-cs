using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheaterService.Models
{
    public class Action
    {
        public int action_id { get; set; }
        public string spectacle_name { get; set; }
        public string hall_name { get; set; }
        public int seats_count { get; set; }
        public string booked_seats { get; set; }
        public string available_seats { get; set; }
    }
}