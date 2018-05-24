using System;
using System.Collections.Generic;

public class Triplet
{
    private readonly int _a,_b,_c;
    public Triplet(int a, int b, int c)
    {
        _a = a;
        _b = b;
        _c = c;
   }

    public int Sum()
    {
        return _a + _b + _c;
    }

    public int Product()
    {
        return _a * _b * _c;
    }

    public bool IsPythagorean()
    {
        return _a * _a + _b * _b == _c * _c;
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        for (int i=minFactor; i<=maxFactor;i+=1)
        {
            for (int j = i; j <=maxFactor; j += 1)
            {
                for (int k = j; k <= maxFactor; k += 1)
                {
                    var t = new Triplet(i, j, k);
                    if (t.IsPythagorean() && (sum == 0 || t.Sum() == sum))
                        yield return t;
                }
            }
        }
    }
}