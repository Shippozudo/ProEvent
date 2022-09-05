using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEvents.Persistence
{
    public class ProEventsContext : DbContext
    {
        public ProEventsContext(DbContextOptions<ProEventsContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Panelist> Panelists { get; set; }
        public DbSet<PanelistEvent> PanelistEvents { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PanelistEvent>()
                .HasKey(PE => new
                {
                    PE.EventId,
                    PE.PanelistId
                });

        }
    }
}
