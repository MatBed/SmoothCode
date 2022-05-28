using Microsoft.EntityFrameworkCore;

namespace MeetupTime.API.Entities;

public class Context : DbContext
{
    private readonly string _connectionString;

    public Context(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }

    public DbSet<Meetup> Meetups { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Lecture> Lectures { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meetup>()
            .HasOne(m => m.Location)
            .WithOne(l => l.Meetup)
            .HasForeignKey<Location>(l => l.MeetupId);

        modelBuilder.Entity<Meetup>()
            .HasMany(m => m.Lectures)
            .WithOne(l => l.Meetup);

        modelBuilder.Entity<User>()
            .HasOne(r => r.Role);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
