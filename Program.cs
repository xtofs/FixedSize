﻿
using System.Runtime.CompilerServices;
using ConstSize;

using Size0 = ConstSize.Z;
using Size1 = ConstSize.S<ConstSize.Z>;
using Size2 = ConstSize.S<ConstSize.S<ConstSize.Z>>;
using Size3 = ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.Z>>>;
using Size4 = ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.Z>>>>;
using Size5 = ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.Z>>>>>;

internal class Program
{
    private static void Main(string[] args)
    {
        var a = new FixedSizeVector<string, Size2>("a", "b");
        var b = new FixedSizeVector<int, Size2>(1, 2);
        var c = new FixedSizeVector<int, Size3>(1, 2, 3);


        var z = a.Zip(b);
        Show(z);

        // ERROR:  var x = a.Zip(c);
        // Console.WriteLine(c);


        // FixedSizeVector<int, Sum<Size2, Size3>
        var y = b.Concat(c);
        Show(y);

        var d = new FixedSizeVector<int, Size5>(1, 2, 3, 4, 5);
        // ERROR: var x = y.Zip(d);
        // even though y's type FixedSizeVector<int, Sum<Size2, Size3>
        // and d's type FixedSizeVector<int, Size5 both represent a vector of size 5, 
        // C# doesn't know the sizes are the same because Sum<Size2,Size3> != Size5 == S<S<S<S<S<Z>>>>>
        // even though both types static .Value propert returns 5.

        Show(Sum<Size2, Size3>.Value);
        Show(Size5.Value);

    }

    private static void Show(object value, [CallerArgumentExpression("value")] string? arg = null)
    {
        Console.WriteLine("{0} = {1}", arg, value);
    }
}
