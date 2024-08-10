using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistServices : IArtistRepository
    {
        private readonly TunifyDbContext _context;

        public ArtistServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task DeleteArtist(int artistId)
        {
            var artist = await _context.Artists.FindAsync(artistId);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Artist>> GetAllArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtistById(int artistId)
        {
            return await _context.Artists.FindAsync(artistId);
        }

        public async Task<Artist> UpdateArtist(int id, Artist artist)
        {
            var oldArtist = await _context.Artists.FindAsync(id);
            if (oldArtist != null)
            {
                oldArtist.Name = artist.Name;
                oldArtist.Bio = artist.Bio;

                await _context.SaveChangesAsync();
                return oldArtist;
            }
            return null;
        }
    }
}
