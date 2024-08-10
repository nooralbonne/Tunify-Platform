using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistByIdAsync(int playlistId);
        Task<Playlist> CreatePlaylistAsync(Playlist playlist);
        Task<Playlist> UpdatePlaylist(int playlistId, Playlist playlist);
        Task DeletePlaylistAsync(int playlistId);
    }
}
