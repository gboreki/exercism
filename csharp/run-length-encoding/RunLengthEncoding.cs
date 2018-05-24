using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RunLengthEncoding
{
    //8:38-8:49 8:58
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        int accum = 0;
        char current;
        int i = 0;

        do
        {
            current = input[i];
            accum = 0;
            while (i < input.Length && input[i] == current) { accum++; i++; };
            if (accum > 1)
            {
                sb.Append(accum.ToString());
            }
            sb.Append(current);
            
        } while (i < input.Length);

        return sb.ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        int i = 0;
        string cur = "";
        do
        {
            while (char.IsNumber(input[i]))
            {
                cur += input[i];
                i++;
            }
            sb.Append(Enumerable.Repeat(input[i], string.IsNullOrEmpty(cur) ? 1 : Int32.Parse(cur)).ToArray());
            cur = "";
            i++;
        } while (i < input.Length);

        return sb.ToString();
    }

}
