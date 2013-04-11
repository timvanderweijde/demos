using System;
using System.Linq.Expressions;

namespace Exercise_5
{
    public class Mapper<TSource, TDestination>
    {
        public void AddMapping(Expression<Func<TSource, object>> sourceProperty,
                               Expression<Func<TDestination, object>> destinationProperty)
        {
            throw new NotImplementedException();
        }

        public TDestination Map(TSource source)
        {

            throw new NotImplementedException();
        }
    }
}