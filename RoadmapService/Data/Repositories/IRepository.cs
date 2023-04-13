namespace RoadmapService.Data;

public interface IRepository<T> where T : class
{
    IAsyncEnumerable<T> Get(Expression<Func<T, bool>> expression);

    Task<T?> GetId(Guid id, CancellationToken cancellationToken = default);

    void Add(T entity);

    void Remove(T entity);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}