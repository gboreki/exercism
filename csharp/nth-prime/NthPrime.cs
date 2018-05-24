using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    //9:03-9:03
    public static int Prime(int nth)
    {
        if (nth <= 0) throw new ArgumentOutOfRangeException();

        if (nth == 1)
            return 2;

        if (nth == 2)
            return 3;

        int i = 5;
        int pos = 2;
        do
        {
            if (IsPrime(i) && ++pos == nth)
                return i;
           
            i+=2;
        } while (true);       
    }

    private static bool IsPrime(int candidate)
    {
        if (candidate % 2 == 0) return false;

        for(int i = 3; i < candidate; i+=2 )
        {
            if (candidate % i == 0)
                return false;
        }

        return true;
    }
}