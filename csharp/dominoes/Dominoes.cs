using System;
using System.Linq;
using System.Collections.Generic;
using Domino = System.Tuple<int, int>;

public static class Dominoes
{
    public static bool CanChainInternal(List<Domino> dominoes, List<Domino> chain)
    {
        bool found = false;
        if (!dominoes.Any())
            return chain.First().Item1 == chain.Last().Item2;   // Check if the chain closes

        foreach (var matched in dominoes.Where(p => Fits(chain.Last(), p)).Distinct())  // find distinct matches on the pieces
        {
            found |= CanChainInternal(
                dominoes.Where(p => p != matched).ToList(),
                chain.Union(
                    Enumerable.Repeat(
                        FlipIfNeed(chain.Last(), matched), 1)).ToList());
        }
        return found;

    }

    //9:21-10:09
    //9:33-10:25
    public static bool CanChain(IEnumerable<Domino> dominoes)
    {
        if (dominoes.Count() == 0)
            return true;

        return CanChainInternal(
            dominoes.Skip(1).ToList(), 
            new List<Domino>(dominoes.Take(1).ToList()));
    }

    private static Domino FlipIfNeed(Domino d1, Domino d2)
    {
        return d1.Item2 != d2.Item1 ? new Domino(d2.Item2, d2.Item1) : d2;
    }

    private static bool Fits(Domino d1, Domino d2)
    {
        return d1.Item2 == d2.Item1 || d1.Item2 == d2.Item2;
    }
}