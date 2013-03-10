using System.Threading;

namespace Exercise_6.Service
{
    public class FinancialService : IFinancialService
    {
        public decimal GetRevenue(Region region)
        {
            // Some really complicated calculation, or maybe its using Oracle
            Thread.Sleep(5000);

            switch (region)
            {
                case Region.America:
                    return 123433;
                case Region.Europe:
                    return 99999;
                case Region.Africa:
                    return 5800;
                case Region.Asia:
                    return 54422.12m;
                case Region.Australia:
                    return 54422;
                default:
                    return 6454.22m;
            }
        }
    }
}