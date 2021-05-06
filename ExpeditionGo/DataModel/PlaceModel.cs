using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.DataModel
{
    public class PlaceModel
    {
        public int PlaceId { get; set; }
        public string PlaceHeading { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PlaceDescription { get; set; }
        public string PlaceContent { get; set; }
        public string PlaceSubContent { get; set; }
        public DateTime PlaceCreated { get; set; }
        public string PlaceContinent { get; set; }
        public string ImageURL { get; set; }

    }
}
