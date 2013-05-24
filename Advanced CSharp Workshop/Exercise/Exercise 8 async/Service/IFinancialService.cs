using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_8.Service
{
    public interface IFinancialService
    {
        Task<decimal> GetRevenueAsync(Region region, CancellationToken token);
        Task<IEnumerable<Region>> GetRegionsAsync();
        Task<IEnumerable<Division>> GetDivisionsAsync();
    }

    public enum Region
    {
        America,
        Europe,
        Africa,
        Asia,
        Australia,
        Antartica
    }
}