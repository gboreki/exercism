using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    // 9:22-9:26
    public static int[] Factors(long number)
    {
        int factor = 2;
        long current = number;
        List<int> factors = new List<int>();
        while(current > 1)
        {
            if (current % factor == 0)
            {
                current /= factor;
                factors.Add(factor);
            }
            else
            {
                factor++;
            }
        }
        return factors.ToArray();
    }
}