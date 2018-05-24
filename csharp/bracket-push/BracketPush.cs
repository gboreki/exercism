using System;
using System.Collections.Generic;
using System.Linq;

public static class BracketPush
{
    class Pair
    {
        public char Open;
        public char Close;
    }

    static Pair[] pairs = new Pair[] {
        new Pair { Open = '(', Close = ')' },
        new Pair { Open = '{', Close = '}' },
        new Pair { Open = '[', Close = ']' },
    };

    //10:27-10:35
    public static bool IsPaired(string input)
    {
        Stack<char> s = new Stack<char>();
        foreach(char c in input)
        {
            if (pairs.Any(p => c == p.Open))
            {
                s.Push(c);
            }

            var opened = pairs.Where(p => c == p.Close).Select(p => p.Open);
            if (opened.Any())
            {
                char closed = s.Count >0 ? s.Pop() : ' ';
                if (closed != opened.Single()) return false;
            }
        }

        return s.Count == 0;
    }
}
