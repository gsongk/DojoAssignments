using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<RSVP> RSVPs { get; set; }
    }
    public class Wedding
    {
        [Key]
        public int wedding_id { get; set; }
        public DateTime date { get; set; }
        public string bride_name { get; set; }
        public string groom_name { get; set; }
        public string address { get; set; }
        public User Planner { get; set; }
        public int user_id { get; set; }
        public List<RSVP> Guests { get; set; }
    }
    public class RSVP
    {
        [Key]
        public int rsvp_id { get; set; }
        public User Guest { get; set; }
        public int user_id { get; set; }
        public int wedding_id { get; set; }
    }
}