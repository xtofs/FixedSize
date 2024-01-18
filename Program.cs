
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
        var a = WriteExpression("a", new FixedSizeVector<string, Size2>("a", "b"));
        var b = WriteExpression("b", new FixedSizeVector<int, Size2>(1, 2));
        var c = WriteExpression("c", new FixedSizeVector<int, Size3>(3, 4, 5));

        var z = WriteExpression("z", a.Zip(b));

        // ERROR:  var x = a.Zip(c);

        var y = WriteExpression("y", b.Concat(c));

        var d = new FixedSizeVector<int, Size5>(1, 2, 3, 4, 5);
        // ERROR: var x = y.Zip(d);
        // even though y's type FixedSizeVector<int, Sum<Size2, Size3>
        // and d's type FixedSizeVector<int, Size5 both represent a vector of size 5, 
        // C# doesn't know the sizes are the same because Sum<Size2,Size3> != Size5 == S<S<S<S<S<Z>>>>>
        // even though both types static .Value propert returns 5.

        WriteExpression(Sum<Size2, Size3>.Value);
        WriteExpression(Size5.Value);

    }

    private static T WriteExpression<T>(T value, [CallerArgumentExpression("value")] string? arg = null)
    {
        Console.WriteLine("{0} = {1}", arg, value);
        return value;
    }

    private static T WriteExpression<T>(string variable, T value, [CallerArgumentExpression(nameof(value))] string? arg = null)
    {
        Console.WriteLine("{0} = {1} = {2}", variable, arg, value);
        return value;
    }
}
