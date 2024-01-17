
namespace ConstSize;


public class FixedSizeVector<TItem, TSize> where TSize : IConstSize
{
    public FixedSizeVector(params TItem[] items) { Items = items; }

    public FixedSizeVector(IEnumerable<TItem> items) { Items = items.ToArray(); }

    public FixedSizeVector() { Items = new TItem[TSize.Value]; }

    public TItem[] Items { get; }

    public TItem this[int ix] => Items[ix];

    public override string ToString() => $"[{string.Join(", ", Items)}]";
}


public static class Extensions
{

    public static FixedSizeVector<(A, B), TSize> Zip<A, B, TSize>(this FixedSizeVector<A, TSize> a, FixedSizeVector<B, TSize> b)
        where TSize : IConstSize
    {
        return new FixedSizeVector<(A, B), TSize>(a.Items.Zip(b.Items, (a, b) => (a, b)));
    }

    public static FixedSizeVector<T, Sum<TSizeA, TSizeB>> Concat<T, TSizeA, TSizeB>(this FixedSizeVector<T, TSizeA> a, FixedSizeVector<T, TSizeB> b)
        where TSizeA : IConstSize
        where TSizeB : IConstSize
    {
        return new FixedSizeVector<T, Sum<TSizeA, TSizeB>>(a.Items.Concat(b.Items));
    }
}
