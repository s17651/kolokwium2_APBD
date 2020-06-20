using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext()
        {
        }

        public ClientDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<ArtistEvent> ArtistEvent { get; set; }

        public DbSet<Organiser> Organiser { get; set; }

        public DbSet<EventOrganiser> EventOrganiser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArtistEvent>()
                .HasKey(a => new { a.IdArtist, a.IdEvent});
            builder.Entity<EventOrganiser>()
                .HasKey(e => new {e.IdEvent, e.IdOrganiser });
        }

    }
}
