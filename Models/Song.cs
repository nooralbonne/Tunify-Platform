namespace Tunify_Platform.Models
{
    public class Song
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public int ArtistsId { get; set; }
        public int AlbumsId { get; set; }
        public int Duration { get; set; }
        public int Genre { get; set; }

        public ICollection<PlaylistSong> playlistSongs { get; set; }
    }
}
