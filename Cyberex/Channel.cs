using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRecord
{
    public class Channel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string copyright { get; set; }
        public string docs { get; set; }
        public string ttl { get; set; }

    }

    
    public class ItemList
    {
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }

    
    }
}
