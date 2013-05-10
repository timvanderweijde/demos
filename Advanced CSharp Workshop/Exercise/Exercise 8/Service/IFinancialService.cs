using System.Collections.Generic;
using System.Threading;

namespace Exercise_8.Service
{
    public interface IFinancialService
    {
        decimal GetRevenue(Region region, CancellationToken token);
        IEnumerable<Region> GetRegions();
        IEnumerable<Division> GetDivisions();
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