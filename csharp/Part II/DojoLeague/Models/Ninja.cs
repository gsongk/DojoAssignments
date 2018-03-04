using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class Ninja
    {
        public int id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public Dojo dojo { get; set; }
        public string description { get; set; }
        public int dojo_id { get; set; }
    }

}