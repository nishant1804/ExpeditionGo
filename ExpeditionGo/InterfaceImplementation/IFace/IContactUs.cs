using ExpeditionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation.IFace
{
    public interface IContactUs
    {
        ContactUs GetById(int id);
        IEnumerable<ContactUs> GetAllContactUs();
        Task AddContactUs(ContactUs blog);
    }
}
