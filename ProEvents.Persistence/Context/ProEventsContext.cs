using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEvents.Persistence.Context
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
                .HasKey(pe => new
                {
                    pe.EventId,
                    pe.PanelistId
                });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialMedia)
                .WithOne(sm => sm.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Panelist>()
               .HasMany(p => p.SocialMedia)
               .WithOne(sm => sm.Panelist)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
