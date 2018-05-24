using System;
using System.Linq;

public static class RotationalCipher
{
    private static char Rotate(char c, int n)
    {
        if (!char.IsLetter(c))
            return c;

        if (char.IsUpper(c) && c + n > 'Z')
            return (char)('A'-1 + (n - ('Z' - c)));

        if (char.IsLower(c) && c + n > 'z')
            return (char)('a'-1 + (n - ('z' - c)));

        return (char) (c + n);
    }

    //10:06-10:16
    public static string Rotate(string text, int shiftKey)
    {
        return new string(text.Select(c => Rotate(c, shiftKey)).ToArray());
    }
}