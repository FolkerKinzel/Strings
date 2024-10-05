#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Buffers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

#if NET461 || NETSTANDARD2_0

/// <summary>Encapsulates a method that receives a span of objects of type <typeparamref name="T"/>
/// and a state object of type <typeparamref name="TArg"/>.</summary>
/// <typeparam name="T">The type of the objects in the span.</typeparam>
/// <typeparam name="TArg">The type of object that represents the state. This type parameter
/// is contravariant. This means that you can either use the specified type or a less
/// derived type.</typeparam>
/// <param name="span">A span of objects of type <typeparamref name="T" />.</param>
/// <param name="arg">A state object of the type <typeparamref name="TArg" />.</param>
public delegate void SpanAction<T, in TArg>(Span<T> span, TArg arg);

#endif