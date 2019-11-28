using ChinookPlayground.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChinookPlayground.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ArtistId = 1,
                    Name = "Billy Cobham"
                });

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumId = 1,
                    Title = "Black Sabbath",
                    ArtistId = 1
                });
        }
    }
}
