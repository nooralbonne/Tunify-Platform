using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet <Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary keys
            modelBuilder.Entity<User>().HasKey(u => u.UsersId);
            modelBuilder.Entity<Subscription>().HasKey(s => s.SubscriptionsId);
            modelBuilder.Entity<Song>().HasKey(s => s.SongsId);
            modelBuilder.Entity<PlaylistSong>().HasKey(ps => ps.PlaylistSongsId);
            modelBuilder.Entity<Playlist>().HasKey(p => p.PlaylistsId);
            modelBuilder.Entity<Artist>().HasKey(a => a.ArtistId);
            modelBuilder.Entity<Album>().HasKey(al => al.AlbumId);

            // Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User { UsersId = 1, UserName = "Noor", Email = "Noorablonne@gmail.com", JoinDate = "2024", SubscriptionId = 1 },
                new User { UsersId = 2, UserName = "reem", Email = "reemablonne@gmail.com", JoinDate = "2024", SubscriptionId = 2 }

            );

            modelBuilder.Entity<Song>().HasData(
            new Song { SongsId = 1, AlbumsId = 1, ArtistsId = 1, Duration = 90, Title = "Tunify", Genre = 1 }
            );

            modelBuilder.Entity<Playlist>().HasData(
            new Playlist { PlaylistsId = 1, CreatedDate = "2024", PlaylistsName = "first song", UsersId = 1 }
            );
        }
    }
}
