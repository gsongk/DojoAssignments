using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class Dojo
    {
        private ICollection<Ninja> _ninjas = new List<Ninja>();
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public ICollection<Ninja> Ninjas
        {
            get { return _ninjas; }
            set { _ninjas = value; }
        }

    }
}