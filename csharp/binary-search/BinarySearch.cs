using System;

public class BinarySearch
{
    // 10:08 - 10:08
    private int[] _input;
    public BinarySearch(int[] input)
    {
        _input = input;
    }

    public int Find(int value)
    {
        return _input.Length > 0 ? FindInternal(value, 0, _input.Length - 1) : -1;
    }

    private int FindInternal(int value, int lower, int upper)
    {
        if (lower == upper)
        {
            return _input[lower] == value ? lower : -1;
        }

        int mid = ((upper - lower) / 2) + lower;
        int candidate = _input[mid];
        if (candidate == value)
            return mid;

        if (candidate > value)
        {
            return FindInternal(value, lower, mid - 1);
        }
        else
        {
            return FindInternal(value, mid + 1, upper);
        }
    }
}