using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.Models
{
    public class BlogLeft
    {
        public int BlogLeftId { get; set; }
        public string BlogLeftHeading { get; set; }
        public string BlogLeftCity { get; set; }
        public string BlogLeftCountry { get; set; }
        public string BlogLeftDescription { get; set; }
        public string BlogLeftContent { get; set; }
        public string BlogLeftSubContent { get; set; }
        public string BlogSide { get; set; }
        public string ImageURLOne { get; set; }
        public string ImageURLThree { get; set; }
        public string ImageURLTwo { get; set; }
        public DateTime BlogLeftCreated { get; set; }

    }
}
