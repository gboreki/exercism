using System;
using System.Collections.Generic;
using System.Linq;

public class Series
{
    private readonly string _input;

    //9:24-9:37
    public Series(string numbers)
    {
        _input = numbers;
    }

    public int[][] Slices(int sliceLength)
    {
        if (sliceLength > _input.Length)
            throw new ArgumentException();

        return Enumerable.Range(0, _input.Length - sliceLength + 1).Select(p => SingleSlice(sliceLength, p)).ToArray();
    }

    private int[] SingleSlice(int sliceLength, int start)
    {
        var result = new int[sliceLength];
        for(int i=start; i<start +sliceLength;i++)
        {
            result[i - start] = ((int)_input[i] - (int) '0');
        }
        return result;
    }
}