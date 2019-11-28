using ChinookPlayground.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChinookPlayground.Domain.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetByFilter();

        Task<Album> GetById(int id);

        Task<IEnumerable<Album>> GetByArtistId(int artistId);

        Task<Album> Update(Album album);

    }
}
