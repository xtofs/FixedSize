

namespace ConstSize;

public interface IConst
{
    static abstract int Value { get; }
}

/// <summary>
/// the const type with value 0 (zero)
/// </summary> 
public class Z : IConst
{
    private Z() { } // never instantiate this

    public static int Value => 0;
}


/// <summary>
/// successor of a const type
/// </summary> 
public class S<CONST> : IConst where CONST : IConst
{
    private S() { } // never instantiate this

    public static int Value => CONST.Value + 1;
}

/// <summary>
/// the sum of two const types
/// </summary> 
public class Sum<A, B> : IConst where A : IConst where B : IConst
{
    private Sum() { } // never instantiate this

    public static int Value => A.Value + B.Value;
}

// TODO: ensure that the compiler understands that Sum<S<A>, B> == Sum<A, S<B>> and Sum<Z, B> == B
// if I am not mistaken, higer order types might allow the following but don't exist in C#
// public class Sum<Z, B> : B where where  B:  IConstSize { }
// public class Sum<S<A>, B> : Sum<A, S<B>> where  A:  IConstSize where  B:  IConstSize { }


