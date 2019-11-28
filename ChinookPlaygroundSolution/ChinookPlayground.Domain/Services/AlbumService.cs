using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinookPlayground.Domain.IRepositories;
using ChinookPlayground.Domain.Models;

namespace ChinookPlayground.Domain.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IGenericRepository<Album> _repository;

        public AlbumService(IGenericRepository<Album> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Album>> GetByFilter()
        {
            return await _repository.GetByFilter();
        }

        // https://www.telerik.com/forums/pass-parameter-to-expression-func-tentity-bool-filter
        public async Task<IEnumerable<Album>> GetByArtistId(int artistId)
        {
            return await _repository.GetByFilter(e => e.ArtistId == artistId);
        }

        public async Task<Album> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Album> Update(Album album)
        {
            return await _repository.Update(album);
        }
    }
}
