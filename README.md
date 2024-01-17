

```csharp

var a = new FixedSizeVector<string, Size2>("a", "b"); // throws at runtime if it has more or less that 2 elements
var b = new FixedSizeVector<int, Size2>(1, 2);
var c = new FixedSizeVector<int, Size3>(1, 2, 3);

var z = a.Zip(b);
// zipping non-matching lendth does not compile
// var z = a.Zip(c);
// The type arguments for method 'Extensions.Zip<A, B, TSize>(FixedSizeVector<A, TSize>, FixedSizeVector<B, TSize>)' cannot be inferred from the usage. Try specifying the type arguments explicitly.CS0411

```