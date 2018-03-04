using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostInTheWoods.Models
{
    public class Trail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int length { get; set; }
        public int elevationChange { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}