﻿using System.Data.Entity;

namespace MvcMovie.Models {
    public class MusicStoreEntities : DbContext {
        //public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<MvcMovie.Models.Movie> Movies { get; set; }
       // public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
