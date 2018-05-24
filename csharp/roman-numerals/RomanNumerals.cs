using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public static class RomanNumeralExtension
{
    private static Dictionary<int, string> _romans = new Dictionary<int, string>();
    static RomanNumeralExtension()
    {
        _romans.Add(1, "I");
        _romans.Add(4, "IV");
        _romans.Add(5, "V");
        _romans.Add(9, "IX");
        _romans.Add(10, "X");
        _romans.Add(40, "XL");
        _romans.Add(50, "L");
        _romans.Add(90, "XC");
        _romans.Add(100, "C");
        _romans.Add(400, "CD");
        _romans.Add(500, "D");
        _romans.Add(900, "CM");
        _romans.Add(1000, "M");
    }

    //10:50-11:20

    public static string ToRoman(this int value)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var v in _romans.Keys.OrderByDescending(p => p))
        {
            while(value >= v)
            {
                sb.Append(_romans[v]);
                value -= v;
            }
        }
        return sb.ToString();
    }
}