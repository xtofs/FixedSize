
using ConstSize;

using Size0 = ConstSize.Z;
using Size1 = ConstSize.S<ConstSize.Z>;
using Size2 = ConstSize.S<ConstSize.S<ConstSize.Z>>;
using Size3 = ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.Z>>>;
using Size4 = ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.S<ConstSize.Z>>>>;

internal class Program
{
    private static void Main(string[] args)
    {
        var a = new FixedSizeVector<string, Size2>("a", "b");
        var b = new FixedSizeVector<int, Size2>(1, 2);
        var c = new FixedSizeVector<int, Size3>(1, 2, 4);


        var z = a.Zip(b);
        Console.WriteLine(z);

        //   var x = a.Zip(c);
        // Console.WriteLine(c);
    }
}
