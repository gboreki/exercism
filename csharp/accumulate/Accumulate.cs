using System;
using System.Linq;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    //8:43-8:49
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        foreach (var o in collection)
        {
            yield return func(o);
        }
    }
}