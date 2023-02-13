using Entidades;
using Microsoft.EntityFrameworkCore;
using Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SpotifyContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Banda> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        public SpotifyContext(DbContextOptions<SpotifyContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
