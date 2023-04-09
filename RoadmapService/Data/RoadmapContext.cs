namespace RoadmapService.Data;

public class RoadmapContext : DbContext
{
    public RoadmapContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roadmap>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Roadmap>()
            .HasOne(x => x.Root).WithOne();

        modelBuilder.Entity<Node>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Node>()
            .HasMany(x => x.Children)
            .WithOne()
            .HasForeignKey(x => x.ParentId);
    }

    public DbSet<Roadmap> Roadmaps => Set<Roadmap>();
    public DbSet<Node> Nodes => Set<Node>();
}