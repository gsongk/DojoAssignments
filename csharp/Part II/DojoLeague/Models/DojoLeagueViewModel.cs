using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class DojoLeagueViewModel
    {
        public List<Ninja> Ninjas { get; set; }
        public List<Dojo> Dojos { get; set; }
        public Ninja Ninja { get; set; }
    }
}