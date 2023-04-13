namespace RoadmapService.Data.Repositories;

public class NodeRepository : Repository<Node>
{
    public NodeRepository(RoadmapContext context) : base(context)
    {
    }

    protected override IQueryable<Node> BaseQuery =>
        Context.Nodes;
}