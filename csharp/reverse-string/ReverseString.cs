using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (input.Length == 0)
            return input;

        char[] reversed = new char[input.Length];
        for (int i = 0; i <input.Length; i++)
        {
            reversed[i] = input[input.Length - 1 - i];
        }
        return new string(reversed);
    }
}