namespace RoadmapService.Data.Repositories;

public interface IRoadmapRepository : IRepository<Roadmap>
{
    IAsyncEnumerable<Roadmap> SearchByName(string query);
}