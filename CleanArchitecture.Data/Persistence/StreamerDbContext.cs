using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infraestructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext(DbContextOptions<StreamerDbContext> options): base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=Streamer;Trusted_Connection=true;MultipleActiveResultSets=true;Integrated Security= true;TrustServerCertificate=True;")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .OnDelete(DeleteBehavior.Restrict); //Relacion 1 a muchos

            modelBuilder.Entity<Director>()
               .HasMany(v => v.Videos)
               .WithOne(d => d.Director)
               .HasForeignKey(d => d.DirectorId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(a => a.Actores)
                .WithMany(v => v.Videos)
                .UsingEntity<VideoActor>(
                    j => j
                    .HasOne(p => p.Actor)
                    .WithMany(p => p.VideoActors)
                    .HasForeignKey(p => p.ActorId),
                    j => j
                    .HasOne(p => p.Video)
                    .WithMany(p => p.VideoActors)
                    .HasForeignKey(p => p.VideoId),
                    j =>
                    {
                        j.HasKey(t => new { t.ActorId, t.VideoId });
                    }
                );

            modelBuilder.Entity<VideoActor>()
                .Ignore(va => va.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Streamer>? Streamers { get; set; }

        public DbSet<Video>? Videos { get; set; }

        public DbSet<Actor>? Actores { get; set; }

        public DbSet<Director>? Directores { get; set; }

    }
}
