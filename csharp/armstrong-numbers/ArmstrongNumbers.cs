using System;
using System.Linq;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    // 8:54-8:05
    public static bool IsArmstrongNumber(int number)
    {
        int running = number;
        List<int> all = new List<int>();
        while (running > 0)
        {
            int digit = running % 10;
            all.Add(digit);
            running = (int) running / 10;
        }

        return all.Sum(p => Math.Pow(p, all.Count)) == number;
    }
}