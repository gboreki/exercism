using System;
using System.Linq;

public static class IsbnVerifier
{
    //9:28-9:40
    public static bool IsValid(string number)
    {
        // validate
        if (!number.All(c => char.IsDigit(c) || c == '-' || c == 'X')
            || number.Where(c => char.IsDigit(c) || c == 'X').Count() != 10)
            return false;

        // Handle last as special case
        char digit = number.Last();
        int last = digit == 'X' ? 10 : digit - '0';

        return (number.Where(char.IsDigit)
            .Take(9)
            .Select((p, i) => (10 - i) * (p - '0'))
            .Sum() + last) % 11 == 0;
    }
}