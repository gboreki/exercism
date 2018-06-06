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
        int accumulator = 0;
        char current;
        int i = 0;

        do
        {
            current = input[i];
            accumulator = 0;
            // Accumulate number of times a character is repeated
            while (i < input.Length && input[i] == current) { accumulator++; i++; };

            // Prefix character with number to repeat
            if (accumulator > 1)
            {
                sb.Append(accumulator.ToString());
            }
            sb.Append(current);
            
        } while (i < input.Length);

        return sb.ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder decodedString = new StringBuilder();
        int i = 0;
        string timesToRepeat = "";
        do
        {
            // repeated characters are prefixed by digits
            // concatenate digits to form full number
            while (char.IsDigit(input[i]))
            {
                timesToRepeat += input[i];
                i++;
            }

            // If no prefix digits, no repetition hence 1
            int repeat = string.IsNullOrEmpty(timesToRepeat) 
                ? 1 
                : Int32.Parse(timesToRepeat);

            var repeatedCharacter = new String(input[i], repeat);
            decodedString.Append(repeatedCharacter);
            timesToRepeat = "";
        }
        while (++i < input.Length);

        return decodedString.ToString();
    }

}
