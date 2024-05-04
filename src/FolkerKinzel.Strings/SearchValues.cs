using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings;

#if !NET8_0_OR_GREATER

/// <summary>
/// The class is a polyfill for the System.Buffers.SearchValues class. The
/// <see cref="SearchValues{T}"/> instances that it creates doesn't have the
/// same excellent performance as those created by the System.Buffers.SearchValues 
/// class in .NET 8.0 and higher.
/// </summary>
public static class SearchValues
{
    /// <summary>
    /// Creates a <see cref="SearchValues{T}"/> instance for <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The set of values.</param>
    /// <returns>A <see cref="SearchValues{T}"/> instance for <paramref name="values"/>.</returns>
    /// <remarks>
    /// <note type="caution">
    /// This method allocates a new <see cref="string"/> from <paramref name="values"/>.
    /// Whenever you can, use the method overload that takes a <see cref="string"/> as argument!
    /// </note>
    /// </remarks>
    public static SearchValues<char> Create(ReadOnlySpan<char> values) => new(values.ToString());

    /// <summary>
    /// Creates a <see cref="SearchValues{T}"/> instance for <paramref name="values"/>.
    /// </summary>
    /// <param name="values">A <see cref="string"/> containing the set of values.</param>
    /// <returns>A <see cref="SearchValues{T}"/> instance for <paramref name="values"/>.</returns>
    public static SearchValues<char> Create(string? values) => new(values);
}

/// <summary>
/// The class is a polyfill for the System.Buffers.SearchValues&lt;Char&gt; class. It hasn't 
/// the same excellent performance as System.Buffers.SearchValues&lt;T&gt;
/// class in .NET 8.0 and higher.
/// </summary>
/// <typeparam name="T">Generic type parameter. Only <see cref="char"/>
/// is supported.</typeparam>
public class SearchValues<T> where T : IEquatable<T>
{
    private readonly string? _values;

    internal SearchValues(string? values) => _values = values;

    internal ReadOnlySpan<char> Span => _values.AsSpan();

    /// <summary>
    /// Searches for the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns><c>true</c> if <paramref name="value"/> was found; otherwise, <c>false</c>.</returns>
    public bool Contains(char value) => Span.Contains(value);
}

#endif
