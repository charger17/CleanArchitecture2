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
            modelBuilder.Entity<Streamer>().HasMany(m => m.Videos).WithOne(m => m.Streamer).HasForeignKey(m => m.StreamerId).OnDelete(DeleteBehavior.Restrict); //Relacion 1 a muchos

            modelBuilder.Entity<Video>().HasMany(p => p.Actores)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Streamer>? Streamers { get; set; }

        public DbSet<Video>? Videos { get; set; }

        public DbSet<Actor>? Actores { get; set; }

        public DbSet<Director>? Directores { get; set; }

    }
}
