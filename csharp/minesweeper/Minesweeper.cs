using System;
using System.Linq;

public static class Minesweeper
{
    static int[] neighbor = new int[] { -1, 0, 1 };

    // 9:03-09:19
    public static string[] Annotate(string[] input)
    {
        if (input.Length == 0) return input;
        char[][] current = StringToCharArray(input);

        for (int i=0;i<input.Length;i++)
        {
            for(int j=0;j<input[i].Length;j++)
            {
                if (current[i][j] == '*')
                {
                    AnnotateBomb(ref current, i, j);
                }
            }
        }

        return CharArrayToString(current);
    }

    public static void AnnotateBomb(ref char[][] input, int i, int j)    
    {
        foreach(var x in neighbor)
        {
            foreach(var y in neighbor)
            {
                IncrementNeighbors(ref input, i + x, j + y);
            }
        }
    }

    public static void IncrementNeighbors(ref char[][] input, int i, int j)
    {
        if (i >=0 && j >=0 && i < input.Length && j < input[i].Length)
        {
            if (input[i][j] == ' ')
            {
                input[i][j] = '1';
            }
            else if (input[i][j] != '*')
            {
                input[i][j]++;
            }
        }
    }

    private static string[] CharArrayToString(char[][] current)
    {
        string[] result = new string[current.Length];
        for (int i = 0; i < current.Length; i++)
        {
            result[i] = new string(current[i]);
        }
        return result;
    }

    private static char[][] StringToCharArray(string[] input)
    {
        char[][] current = new char[input.Length][];
        int count = 0;
        do
        {
            current[count] = input[count].ToArray();
        } while (++count < input.Length);

        return current;
    }
}
