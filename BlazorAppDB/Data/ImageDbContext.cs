using Microsoft.EntityFrameworkCore;

namespace BlazorAppDB.Data
{
    public class ImageDbContext(DbContextOptions<ImageDbContext> options) : DbContext(options)
    {
        public DbSet<CustomImageData> ImageCollections { get; set; }

    }
}
