using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistServices : IPlaylistRepository
    {
        private readonly TunifyDbContext _context;
        public PlaylistServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
        {
            await _context.Playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task DeletePlaylistAsync(int playlistId)
        {
            var deleted = await _context.Playlists.FindAsync(playlistId);
            _context.Playlists.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlist>> GetAllPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int playlistId)
        {
            //var oneSong = _context.songs.Where(x => x.Equals(id));
            var onePlaylist = await _context.Playlists.FindAsync(playlistId);
            return onePlaylist;
        }

        public async Task<Playlist> UpdatePlaylist(int playlistId, Playlist playlist)
        {
            var oldPlaylist = await _context.Playlists.FindAsync(playlistId);
            oldPlaylist = playlist;
            await _context.SaveChangesAsync();
            return oldPlaylist;
        }
    }
}
