

namespace ConstSize;

public interface IConstSize
{
    static abstract int Value { get; }
}

public class Z : IConstSize
{
    public static int Value => 0;
}

public class S<F> : IConstSize where F : IConstSize
{
    public static int Value => 1 + F.Value;
}


