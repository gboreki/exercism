using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public static class Rectangles
{
    //10:10-10:50
    public static int Count(string[] rows)
    {
        int count = 0;
        var points = FindPoints(rows);

        foreach (var p in points)
        {
            // Find candidates in the same row
            var sameRow = points.Where(n =>
                p.Y == n.Y                      // same row
                && n.X > p.X                    // that came after
                && IsHorizontal(p, n, rows));   // and forms a line

            // Find cancidates in the same column
            var sameColumn = points.Where(n =>
                p.X == n.X
                && n.Y > p.Y
                && IsVertical(p, n, rows));

            foreach (var row in sameRow)
            {
                foreach (var col in sameColumn)
                {
                    // Find candidates to close the rectangle
                    count += points.Count(n =>
                        row.X == n.X                        // same row as the candidate
                        && col.Y == n.Y                     // same column as the column candidate
                        && IsVertical(row, n, rows)         // forms both vertical and horizontal lines with candidates
                        && IsHorizontal(col, n, rows));
                }
            }
        }
        return count;
    }

    private static List<Point> FindPoints(string[] rows)
    {
        List<Point> points = new List<Point>();

        // Scan and find all points (+)
        for (int i = 0; i < rows.Length; i++)
        {
            int start = 0;
            int lastIndex = rows[i].IndexOf('+', start); ;
            while (lastIndex >= 0)
            {
                start = lastIndex + 1;
                Point p = new Point(lastIndex, i);
                points.Add(p);
                lastIndex = rows[i].IndexOf('+', start);
            }
        }

        return points;
    }

    private static bool IsHorizontal(Point p1, Point p2, string[] rows)
    {
        if (p1.Y != p2.Y)
        {
            return false;
        }

        for (int i = p1.X; i <= p2.X; i++)
        {
            if (!IsHorizontalLine(rows[p1.Y][i]))
                return false;
        }
        return true;

    }

    private static bool IsVertical(Point p1, Point p2, string[] rows)
    {
        if (p1.X != p2.X)
        {
            return false;
        }
        for (int i = p1.Y; i <= p2.Y; i++)
        {
            if (!IsVerticalLine(rows[i][p1.X]))
                return false;
        }
        return true;

    }

    private static bool IsHorizontalLine(char c)
    {
        return c == '+' || c == '-';

    }

    private static bool IsVerticalLine(char c)
    {
        return c == '+' || c == '|';

    }
}