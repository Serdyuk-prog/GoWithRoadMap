namespace RoadmapService.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected RoadmapContext Context;

    protected Repository(RoadmapContext context)
    {
        Context = context;
    }

    protected virtual IQueryable<T> BaseQuery =>
        Context.Set<T>();

    public IAsyncEnumerable<T> Get(Expression<Func<T, bool>> expression) =>
        BaseQuery.Where(expression).AsAsyncEnumerable();

    public virtual async Task<T?> GetId(Guid id, CancellationToken cancellationToken = default) =>
        await Context.Set<T>().FindAsync(new object?[] { id }, cancellationToken);

    public void Add(T entity) =>
        Context.Set<T>().Add(entity);

    public void Remove(T entity) =>
        Context.Set<T>().Remove(entity);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        Context.SaveChangesAsync(cancellationToken);
}