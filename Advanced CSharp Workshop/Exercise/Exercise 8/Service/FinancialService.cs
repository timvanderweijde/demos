using System;
using System.Collections.Generic;
using System.Threading;

namespace Exercise_8.Service
{
    public class Division
    {
        public Region Region { get; set; }
        public string Name { get; set; }
    }

    public class FinancialService : IFinancialService
    {
        public IEnumerable<Region> GetRegions()
        {
            Thread.Sleep(1500);

            return (Region[]) Enum.GetValues(typeof (Region));
        }

        public IEnumerable<Division> GetDivisions()
        {
            Thread.Sleep(1500);

            return new[]
                {
                    new Division {Name = "North America", Region = Region.America},
                    new Division {Name = "South America", Region = Region.America},
                    new Division {Name = "Western Europe", Region = Region.Europe},
                    new Division {Name = "Eastern Europe", Region = Region.Europe},
                    new Division {Name = "North Africa", Region = Region.Africa},
                    new Division {Name = "South Africa", Region = Region.Africa},
                    new Division {Name = "Central Asia", Region = Region.Asia},
                    new Division {Name = "Central Australia", Region = Region.Australia}
                };
        }

        public decimal GetRevenue(Region region)
        {
            // Some really complicated calculation, or its using Oracle
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
            }

            switch (region)
            {
                case Region.America:
                    return 123433;
                case Region.Europe:
                    return 99999;
                case Region.Africa:
                    return 5800;
                case Region.Asia:
                    throw new InvalidOperationException("The Asia region does not support revenue calculation.");
                case Region.Australia:
                    return 54422;
                default:
                    return 6454.22m;
            }
        }
    }
}