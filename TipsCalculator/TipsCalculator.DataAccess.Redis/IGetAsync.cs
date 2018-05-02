using System.Threading.Tasks;

namespace TipsCalculator.DataAccess.Redis
{
    public interface IGetAsync<T>
    {
        Task<T> GetAsync(string key);
    }
}
