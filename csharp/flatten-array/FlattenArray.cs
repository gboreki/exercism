using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    // 9:24-9:28
    public static IEnumerable Flatten(IEnumerable input)
    {
        return FlattenEnumerable(input);
    }

    public static IEnumerable<object> FlattenInternal(object input) 
    {
         yield return input;
    }

    public static IEnumerable<object> FlattenEnumerable(IEnumerable input) 
    {
        return input.Cast<object>().Where(p => p != null).Select(p => FlattenEnumerable(p as IEnumerable)).SelectMany(p => p); 
    }
}