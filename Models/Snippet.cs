using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playster
{
    public class Snippet
    {
       
        public string Title { get; set; }
        public string Descripption { get; set; }
        public string ChannelTitle { get; set; }
        public string PublishTime { get; set; }

        public Snippet(string Title, string Description, string Channel, string Time)
        {
            this.Title = Title;
            this.Descripption = Description;
            this.ChannelTitle = Channel;
            this.PublishTime = Time;
        }
    }

}
