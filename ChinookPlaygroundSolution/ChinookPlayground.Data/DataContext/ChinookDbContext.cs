using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChinookPlayground.Domain.Models;
using ChinookPlayground.Data.Extensions;

namespace ChinookPlayground.Data.DataContext
{
    public class ChinookDbContext : DbContext
    {
        public ChinookDbContext(DbContextOptions<ChinookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://docs.microsoft.com/en-us/ef/core/modeling/keys
            //
            // primary keys
            /*modelBuilder.Entity<Artist>()
                .HasKey(c => c.ArtistId);*/

            // setup a composite key
            // modelBuilder.Entity<Car>()
            //    .HasKey(c => new { c.State, c.LicensePlate });

            // maximum length for a property
            /*modelBuilder.Entity<Artist>()
                .Property(b => b.Name)
                .HasMaxLength(333);*/

            // https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx
            //
            // configures one-to-many relationship
            /*modelBuilder.Entity<Album>()
                .HasOne<Artist>(s => s.Artist)
                .WithMany(g => g.Albums)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        //public DbSet<MediaType> MediaTypes { get; set; }
        //public DbSet<Playlist> Playlists { get; set; }
        //public DbSet<Track> Tracks { get; set; }
        //public DbSet<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
