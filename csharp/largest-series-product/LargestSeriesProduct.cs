using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    //9:16-9:30
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span == 0)
            return 1;

        if (String.IsNullOrEmpty(digits) || !digits.All(p => char.IsNumber(p)) || digits.Length < span || span < 0)
            throw new ArgumentException();

        IEnumerable<int> numbers = digits.ToArray().Select(p => (int) char.GetNumericValue(p));

        return Enumerable.Range(0, numbers.Count() - span + 1)
            .Max(i => numbers.Skip(i).Take(span)
            .Aggregate((cur, next) => cur * next));
    }
}