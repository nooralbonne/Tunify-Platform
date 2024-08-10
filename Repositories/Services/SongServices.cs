using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tunify_Platform.Repositories.Services
{
    public class SongServices : ISongRepository
    {
        private readonly TunifyDbContext _context;

        public SongServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Song> CreateSong(Song song)
        {
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Song>> GetAllSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> GetSongById(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<Song> UpdateSong(int id, Song song)
        {
            var oldSong = await _context.Songs.FindAsync(id);
            if (oldSong != null)
            {
                oldSong.Title = song.Title;
                oldSong.ArtistsId = song.ArtistsId;
                oldSong.AlbumsId = song.AlbumsId;
                oldSong.Duration = song.Duration;
                oldSong.Genre = song.Genre;

                await _context.SaveChangesAsync();
                return oldSong;
            }
            return null;
        }
    }
}
