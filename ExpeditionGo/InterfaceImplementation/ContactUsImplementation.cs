using ExpeditionGo.Data;
using ExpeditionGo.InterfaceImplementation.IFace;
using ExpeditionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation
{
    public class ContactUsImplementation : IContactUs
    {
        private readonly ApplicationDbContext _context;

        public ContactUsImplementation(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddContactUs(ContactUs blog)
        {
            _context.ContactUss.Add(blog);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ContactUs> GetAllContactUs()
        {
            return _context.ContactUss;
        }

        public ContactUs GetById(int id)
        {
            return _context.ContactUss.Where(q => q.Id == id)
               .First();
        }
    }
}
