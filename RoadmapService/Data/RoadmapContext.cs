namespace RoadmapService.Data;

public class RoadmapContext : DbContext
{
    public RoadmapContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roadmap>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Roadmap>()
            .HasMany(x => x.Content)
            .WithOne();

        modelBuilder.Entity<Node>()
            .HasKey(x => x.Id);
    }

    public DbSet<Roadmap> Roadmaps => Set<Roadmap>();
    public DbSet<Node> Nodes => Set<Node>();
}