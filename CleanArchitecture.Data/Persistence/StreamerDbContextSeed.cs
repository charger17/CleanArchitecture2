using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infraestructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> looger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                looger.LogInformation("Se insertan nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer
                {
                    CreatedBy = "carlos",
                    Nombre = "Maxi HBP",
                    Url = "https://www.hbp.com",
                },
               new Streamer
                {
                    CreatedBy = "carlos",
                    Nombre = "Amazon VIP",
                    Url = "https://www.amazonvip.com",
                }
            };
        }
    }
}
