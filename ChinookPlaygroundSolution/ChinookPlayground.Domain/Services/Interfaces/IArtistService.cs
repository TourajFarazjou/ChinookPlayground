using ChinookPlayground.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChinookPlayground.Domain.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetByFilter();

        Task<Artist> GetById(int id);

        Task<Artist> Update(Artist artist);
    }
}
