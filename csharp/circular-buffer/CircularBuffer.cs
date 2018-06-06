using System;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    int _free = 0;
    int _older = 0;
    int currentCapacity = 0;

    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
    }

    private void Increment(ref int index)
    {
        index++;
        if (index == _buffer.Length)
        {
            index = 0;
        }
    }
    private T GetThenIncrement(ref int index)
    {
        T value = _buffer[index];
        Increment(ref index);
        return value;
    }

    private void SetThenIncrement(ref int index, T value)
    {
        _buffer[index] = value;
        Increment(ref index);
    }

    public T Read()
    {
        if (currentCapacity == 0)
        {
            throw new InvalidOperationException();
        }
        currentCapacity--;
        return GetThenIncrement(ref _older);
    }

    public void Write(T value)
    {
        if (currentCapacity < _buffer.Length)
        {
            SetThenIncrement(ref _free, value);
            currentCapacity++;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Overwrite(T value)
    {
        if (currentCapacity < _buffer.Length)
        {
            Write(value);
        }
        else
        {
            SetThenIncrement(ref _older, value);
        }
    }

    public void Clear()
    {
        currentCapacity = 0;
        _free = 0;
        _older = 0;
    }
}