using System;
using System.Collections;

public static class Pangram
{
    private const int TotalLetters = 26;

    // 10:49-11:00
    public static bool IsPangram(string input)
    {
        int found = 0;
        int i = 0;
        BitArray foundLetters = new BitArray(TotalLetters);

        while (found < TotalLetters && i < input.Length)
        {
            char c = input[i];
            var value = (int) c;
            if (value < 'a')
            {
                value -= 'A';
            }
            else
            {
                value -= 'a';
            }

            // handle simbols and spaces
            if (char.IsLetter(c) && !foundLetters[value])
            {
                found++;
                foundLetters[value] = true;
            }

            i++;
        }

        return found == TotalLetters;
    }
}
