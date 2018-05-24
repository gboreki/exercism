using System;
using System.Linq;
using System.Collections.Generic;

public static class Etl
{

    //9:11-9:15
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        var dic = new Dictionary<string, int>();

        foreach(var key in old.Keys)
        {
            foreach(var value in old[key])
            {
                dic[value.ToLower()] = key;
            }
        }

        return dic;
    }
}