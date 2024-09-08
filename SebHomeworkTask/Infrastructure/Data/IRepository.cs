namespace SebHomeworkTask.Infrastructure.Data;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task AddRange(IEnumerable<T> entities);
}