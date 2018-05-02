using System.Threading.Tasks;

namespace TipsCalculator.DataAccess.WSVueling
{
    public interface IWSVueling<T>
    {
        Task<T> GetAsync(string apiPath);
    }
}
