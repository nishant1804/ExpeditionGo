using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.DataModel
{
    public class ContactUsModel
    {
        public int ContactUsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string UserEmail { get; set; }
        public DateTime ContactCreated { get; set; }
    }
}
