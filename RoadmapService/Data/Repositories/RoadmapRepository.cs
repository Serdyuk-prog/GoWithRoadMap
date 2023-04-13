namespace RoadmapService.Data.Repositories;

public class RoadmapRepository : Repository<Roadmap>, IRoadmapRepository
{
    public RoadmapRepository(RoadmapContext context) : base(context)
    {
    }

    protected override IQueryable<Roadmap> BaseQuery =>
        Context.Roadmaps.Include(x => x.Content);

    public IAsyncEnumerable<Roadmap> SearchByName(string query) =>
        BaseQuery.Where(x => EF.Functions.ILike(x.Title, $"%{query}%"))
            .AsAsyncEnumerable();

}