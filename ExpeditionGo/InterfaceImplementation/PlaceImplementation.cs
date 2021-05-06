using ExpeditionGo.Data;
using ExpeditionGo.InterfaceImplementation.IFace;
using ExpeditionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation
{
    public class PlaceImplementation : IPlace
    {
        private readonly ApplicationDbContext _context;

        public PlaceImplementation(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPlace(Place place)
        {
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
        }

        public Task DeletePlace(int placeid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetAllPlace()
        {
            return _context.Places;
        }

        public Place GetByPlaceId(int id)
        {
            return _context.Places.Where(q => q.PlaceId == id)
               .First();
        }

        public BlogLeft GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
