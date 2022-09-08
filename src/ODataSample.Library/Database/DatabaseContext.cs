using Microsoft.EntityFrameworkCore;
using ODataSample.Library.Models;

namespace ODataSample.Library.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; } = null!;
    public virtual DbSet<Meeting> Meetings { get; set; } = null!;
    public virtual DbSet<Reminder> Reminders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.ToTable("Calendars");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Owner)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.ToTable("Meetings");

            entity.HasKey(m => m.Id);

            entity.HasIndex(m => m.CalendarId);

            entity.Property(m => m.Description)
                .HasMaxLength(800);

            entity.Property(m => m.Title)
                .HasMaxLength(200);

            entity.HasOne(m => m.Calendar)
                .WithMany(c => c.Meetings)
                .HasForeignKey(m => m.CalendarId);
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.ToTable("Reminders");

            entity.HasKey(r => r.Id);

            entity.HasIndex(r => r.MeetingId);

            entity.HasOne(r => r.Meeting)
                .WithMany(m => m.Reminders)
                .HasForeignKey(r => r.MeetingId);
        });
    }
}