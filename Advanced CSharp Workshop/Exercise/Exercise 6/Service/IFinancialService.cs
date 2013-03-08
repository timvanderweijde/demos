namespace Exercise_6.Service
{
    public interface IFinancialService
    {
        decimal GetRevenue(Region region);
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