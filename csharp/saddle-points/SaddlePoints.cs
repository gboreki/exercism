using System;
using System.Collections.Generic;
using System.Linq;

public sealed class SaddlePoints
{
    private readonly int[,] _values;
    private readonly int _rowCount;
    private readonly int _colCount;

    //9:30-9:50
    //8:45-8:48
    public SaddlePoints(int[,] values)
    {
        _values = values;
        _rowCount = _values.GetLength(0);
        _colCount = _values.GetLength(1);

    }

    public bool IsSaddle(Tuple<int, int> candidate)
    {
        var value = _values[candidate.Item1, candidate.Item2];

        return Enumerable.Range(0, _rowCount).All(i => value >= _values[candidate.Item1, i])
            && Enumerable.Range(0, _colCount).All(i => value <= _values[i, candidate.Item2]);
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        for (int row = 0; row < _values.GetLength(0); row++)
        {
            for (int column = 0; column < _values.GetLength(1); column++)
            {
                var candidate = Tuple.Create(row, column);
                if (IsSaddle(candidate))
                {
                    yield return candidate;
                }
            }
        }
    }
}