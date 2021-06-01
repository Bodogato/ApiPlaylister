using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playster
{
    public class Showcase_List
    {
        public List<Showcase> items = new List<Showcase>();
    }
    public class Showcase
    {
        public Snippet snippet { get; set; }
        public Details contentDetails { get; set; }
        public Id id { get; set; }
    }

}