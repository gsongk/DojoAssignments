using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace restaurant.Models
{
    //may not need abstract class Base Entity...but I think it just allows for easy inheritence of common stuff
    public abstract class BaseEntity { }
    public class Review : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string restaurrant { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string rev { get; set; }

        [Required]
        public int stars { get; set; }

        [Required]
        public DateTime review_date { get; set; }
    }
}