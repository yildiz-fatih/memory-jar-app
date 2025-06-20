using MemoryJar.Data;
using Microsoft.EntityFrameworkCore;

namespace MemoryJar.API
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext ctx)
        {
            // Apply any pending migrations
            ctx.Database.Migrate();

            // If there’s already data, cancel
            if (ctx.Jars.Any()) return;

            // Insert dummy jars
            ctx.Jars.AddRange(
                new Jar { Name = "Welcome Jar",      IsPublic = false },
                new Jar { Name = "Trip Memories",     IsPublic = false },
                new Jar { Name = "Event Highlights",  IsPublic = true  },
                new Jar { Name = "Family Time Capsule", IsPublic = false },
                new Jar { Name = "Public Showcase",   IsPublic = true  }
            );

            ctx.SaveChanges();
        }
    }
}
