using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinookPlayground.Domain.IRepositories;
using ChinookPlayground.Domain.Models;

namespace ChinookPlayground.Domain.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IGenericRepository<Artist> _repository;

        public ArtistService(IGenericRepository<Artist> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Artist>> GetByFilter()
        {
            return await _repository.GetByFilter();
        }

        public async Task<Artist> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Artist> Update(Artist artist)
        {
            return await _repository.Update(artist);
        }
    }
}
