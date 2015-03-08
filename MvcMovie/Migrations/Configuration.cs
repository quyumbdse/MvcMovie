namespace MvcMovie.Migrations
{
    using MvcMovie.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.MusicStoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovie.Models.MusicStoreEntities context)
        {
            if (context.Albums.Any())
                return;

            var genres = AddGenres(context);
            var artists = AddArtists(context);
            AddAlbums(context, genres, artists);
            context.SaveChanges();

        }
        private static void AddAlbums(MusicStoreEntities context, List<Genre> genres, List<Artist> artists)
        {
            context.Albums.AddOrUpdate(new Album { Title = "...And Justice For All", Genre = genres.Single(g => g.Name == "Metal") });
            context.Albums.AddOrUpdate(new Album { Title = "10,000 Days", Genre = genres.Single(g => g.Name == "Rock"),  });
            context.Albums.AddOrUpdate(new Album { Title = "11i", Genre = genres.Single(g => g.Name == "Electronic"), });
            context.Albums.AddOrUpdate(new Album { Title = "1960", Genre = genres.Single(g => g.Name == "Indie") });
            context.Albums.AddOrUpdate(new Album { Title = "4x4=12 ", Genre = genres.Single(g => g.Name == "Electronic") });
            context.Albums.AddOrUpdate(new Album { Title = "A Lively Mind", Genre = genres.Single(g => g.Name == "Electronic") });
            context.Albums.AddOrUpdate(new Album { Title = "A Rush of Blood to the Head", Genre = genres.Single(g => g.Name == "Rock") });
            context.Albums.AddOrUpdate(new Album { Title = "A Winter Symphony", Genre = genres.Single(g => g.Name == "Classical") });
        }
        private static List<Artist> AddArtists(MusicStoreEntities context)
        {
            var artists = new List<Artist>
            {
                new Artist { Name = "65daysofstatic" },
                new Artist { Name = "Above & Beyond" },
                new Artist { Name = "Above the Fold" },
                new Artist { Name = "Adicts" },
                new Artist { Name = "Al di Meola" },
                new Artist { Name = "Alabama Shakes" },
                new Artist { Name = "Alanis Morissette" },
                new Artist { Name = "Alice in Chains" },
                new Artist { Name = "Alison Krauss" },
                new Artist { Name = "Amon Amarth" },
                new Artist { Name = "Amon Tobin" },
                new Artist { Name = "Amr Diab" },
                new Artist { Name = "Anthrax" },
                new Artist { Name = "Aqua" },
                new Artist { Name = "Armand Van Helden" },
                new Artist { Name = "Arcade Fire" },
                 };
            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();
            return artists;
    }
        private static List<Genre> AddGenres(MusicStoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Pop" },
                new Genre { Name = "Rock" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Metal" },
                new Genre { Name = "Electronic" },
                new Genre { Name = "Blues" },
                new Genre { Name = "Latin" },
                new Genre { Name = "Rap" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Alternative" },
                new Genre { Name = "Country" },
                new Genre { Name = "R&B" },
                new Genre { Name = "Indie" },
                new Genre { Name = "Punk" },
                new Genre { Name = "World" }
            };

            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();
            return genres;
        }
}
    }
