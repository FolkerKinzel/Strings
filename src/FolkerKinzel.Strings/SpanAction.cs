//namespace System.Buffers;
namespace FolkerKinzel.Strings;

#if NET45 || NETSTANDARD2_0

/// <summary>
/// Polyfill für das ab .NET Standard 2.0 verfügbare Delegat System.Buffers.SpanAction&lt;T,TArg&gt;.
/// </summary>
/// <typeparam name="T">Der Typ der Objekte in der Spanne.</typeparam>
/// <typeparam name="TArg">Der Typ des Objekts, das den Zustand darstellt.
/// Dieser Typparameter ist kontravariant. Das bedeutet, dass Sie entweder den angegebenen Typ oder 
/// einen weniger abgeleiteten Typ verwenden können. </typeparam>
/// <param name="span">Eine Spanne von Objekten des Typs <typeparamref name="T"/>.</param>
/// <param name="arg">Ein Zustandsobjekt des Typs <typeparamref name="TArg"/>.</param>
public delegate void SpanAction<T, in TArg>(Span<T> span, TArg arg);

#endif
