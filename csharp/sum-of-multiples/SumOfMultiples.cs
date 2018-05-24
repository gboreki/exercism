using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    //8:22-8:26
    //8:39-8:41
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(1, max - 1)
            .Where(n => multiples.Any(p => n % p == 0))
            .Sum();
    }
}