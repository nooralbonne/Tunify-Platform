using System.Collections.Generic;
using System.Threading.Tasks;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> CreateArtist(Artist artist);
        Task<List<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int artistId);
        Task<Artist> UpdateArtist(int id, Artist artist);
        Task DeleteArtist(int id);
    }
}
