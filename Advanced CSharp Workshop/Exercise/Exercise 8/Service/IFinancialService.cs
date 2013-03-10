using System.Collections.Generic;

namespace Exercise_8.Service
{
    public interface IFinancialService
    {
        decimal GetRevenue(Region region);
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