namespace FolkerKinzel.Strings;

#if NET45 || NETSTANDARD2_0

    /// <summary>Polyfill for the delegate System.Buffers.SpanAction&lt;T,TArg&gt;.</summary>
    /// <typeparam name="T">The type of the objects in the span.</typeparam>
    /// <typeparam name="TArg">The type of object that represents the state. This type parameter
    /// is contravariant. This means that you can either use the specified type or a less
    /// derived type.</typeparam>
    /// <param name="span">A span of objects of type <typeparamref name="T" />.</param>
    /// <param name="arg">A state object of the type <typeparamref name="TArg" />.</param>
public delegate void SpanAction<T, in TArg>(Span<T> span, TArg arg);

#endif
