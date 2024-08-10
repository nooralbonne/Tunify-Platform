using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(int id);
        Task<Song> CreateSong(Song song);
        Task<Song> UpdateSong(int id, Song song);
        Task DeleteSong(int id);
    }
}
