using ASP.NET.crud.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.crud.Persistence
{
    public class DevEventsDb : DbContext
    {
        public DevEventsDb(DbContextOptions<DevEventsDb> options): base(options) {
        }
          public DbSet<DevEvents> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeaker { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvents>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Title).IsRequired(false);
                e.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnType("varchar(200");
                ;
                e.Property(e => e.StartDate)
                .HasColumnName("Start_Date");
                e.Property(e => e.EndDate)
                .HasColumnName("End_Date");
                e.HasMany(e => e.Speaker)
                .WithOne()
                .HasForeignKey(e => e.DevEventId);
            });
            builder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(e => e.Id);
            });
        }
    }
  }



