using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playster
{
    public class Showcase_List_det
    {
        public List<Showcase_det> items = new List<Showcase_det>();
    }
    public class Showcase_det
    {
        public Snippet snippet { get; set; }
        public Details contentDetails { get; set; }
        public string id { get; set; }
    }
    public class Details
    {
        public string duration { get; set; }
        public string dimension { get; set; }
        public string definition { get; set; }
        public string caption { get; set; }

        public Details(string duration, string dimension, string definition, string caption)
        {
            this.duration = duration;
            this.dimension = dimension;
            this.definition = definition;
            this.caption = caption;
        }
    }

    public class Detail_List { }


}