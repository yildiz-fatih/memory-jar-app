using Microsoft.EntityFrameworkCore;

namespace MemoryJar.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
    public DbSet<Jar> Jars => Set<Jar>();
}

public class Jar
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsPublic { get; set; }
}
