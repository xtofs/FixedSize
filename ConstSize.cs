

namespace ConstSize;

public interface IConstSize
{
    static abstract int Value { get; }
}


/// <summary>
/// successor of a const type
/// </summary> 
public class S<CONST> : IConstSize where CONST : IConstSize
{
    private S() { } // never instantiate this

    public static int Value => CONST.Value + 1;
}


/// <summary>
/// the const type with value 0 (zero)
/// </summary> 
public class Z : IConstSize
{
    private Z() { } // never instantiate this

    public static int Value => 0;
}

/// <summary>
/// the sum of two const types
/// </summary> 
public class Sum<A, B> : IConstSize where A : IConstSize where B : IConstSize
{
    private Sum() { } // never instantiate this

    public static int Value => A.Value + B.Value;
}

