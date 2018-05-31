using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    //8:41-8:48
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException();

        HashSet<int> primes = new HashSet<int>(Enumerable.Range(2, limit -1));
        int n = 2;

        while (n <= limit)
        {
            if (primes.Contains(n))
            {

                for (int i = n + n; i <= limit; i += n)
                {
                    primes.Remove(i);
                }
            }
            n++;
        }

        return primes.ToArray();
    }
}