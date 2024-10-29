using DbContextTests.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbContextTests;

public class TestDbContext : DbContext
{
    //public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
    //new LoggerFactory(new[] {
    //    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    //});

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbContextTest;Trusted_Connection=True;MultipleActiveResultSets=true;",
            options =>
            {
                //options.MinBatchSize(1);
                //options.MaxBatchSize(100);
                //options.EnableRetryOnFailure
            });
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paragraph>()
            .HasOne(c => c.Post)
            .WithMany()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TrackedBlog>()
            .ToTable(
            "TrackingInfo",
            tableBuilder => tableBuilder.Property(x => x.Id).HasColumnName("BlogId")
        );

        modelBuilder.Entity<Appointment>(x =>
        {
            x.ToTable("Appointments");
            x.OwnsOne(
                appointment => appointment.Utm, 
                utm =>
                {
                    utm.ToTable("TrackedAppointments");
                    utm.Property(x => x.Medium).HasColumnName("test");

                    // Configure FK to the owner (appointment)
                    utm.WithOwner().HasForeignKey("AppointmentId");

                    // Make sure it's optional
                    //utm.HasForeignKey(a => a.AppointmentId);
                }
            );
        });
    }
}
