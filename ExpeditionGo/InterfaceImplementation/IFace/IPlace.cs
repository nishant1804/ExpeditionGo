using ExpeditionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation.IFace
{
    public interface IPlace
    {
        Place GetByPlaceId(int id);
        IEnumerable<Place> GetAllPlace();
        Task AddPlace(Place place);
        Task DeletePlace(int Placeid);
    }
}
