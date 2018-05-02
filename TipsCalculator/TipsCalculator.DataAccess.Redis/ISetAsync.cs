using System.Threading.Tasks;

namespace TipsCalculator.DataAccess.Redis
{
    public interface ISetAsync<T>
    {
        Task<T> AddAsync(T entity, string key);
    }
}
