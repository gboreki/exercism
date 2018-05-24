using System;
using System.Linq;

public static class Hamming
{
    //8:53-8:55
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();

        return Enumerable.Range(0, firstStrand.Length).Sum(p => firstStrand[p] != secondStrand[p] ? 1 : 0);
    }
}