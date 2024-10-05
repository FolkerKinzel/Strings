namespace FolkerKinzel.Strings;

/// <summary>
/// The class is a polyfill for the System.Buffers.SearchValues class.
/// </summary>
public static class SearchValuesPolyfill
{
    /// <summary>
    /// Creates a <see cref="SearchValuesPolyfill{T}"/> instance for <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The set of values.</param>
    /// <returns>A <see cref="SearchValuesPolyfill{T}"/> instance for <paramref name="values"/>.</returns>
    /// <remarks>
    /// <note type="tip">
    /// This method allocates a new <see cref="string"/> from <paramref name="values"/> when used with
    /// framework versions lower than .NET 8.0.
    /// Whenever you can, use the method overload that takes a <see cref="string"/> as argument!
    /// </note>
    /// </remarks>
    public static SearchValuesPolyfill<char> Create(ReadOnlySpan<char> values)
#if NET8_0_OR_GREATER
        => new(SearchValues.Create(values));
#else
        => new(values.ToString());
#endif

    /// <summary>
    /// Creates a <see cref="SearchValuesPolyfill{T}"/> instance for <paramref name="values"/>.
    /// </summary>
    /// <param name="values">A <see cref="string"/> containing the set of values.</param>
    /// <returns>A <see cref="SearchValuesPolyfill{T}"/> instance for <paramref name="values"/>.</returns>
    public static SearchValuesPolyfill<char> Create(string? values)
#if NET8_0_OR_GREATER
        => new(SearchValues.Create(values));
#else
        => new(values);
#endif
}

/// <summary>
/// The class is a polyfill for the System.Buffers.SearchValues&lt;Char&gt; class. It hasn't 
/// the same excellent performance as the System.Buffers.SearchValues&lt;T&gt;
/// class when used with framework versions lower than .NET 8.0.
/// </summary>
/// <typeparam name="T">Generic type parameter. Only <see cref="char"/>
/// is currently supported.</typeparam>
public class SearchValuesPolyfill<T> where T : IEquatable<T>
{
#if NET8_0_OR_GREATER
    internal SearchValuesPolyfill(SearchValues<char> values)
       => Value = values;

    internal readonly SearchValues<char> Value;
#else
    internal SearchValuesPolyfill(string? values)
        => _values = values;

    private readonly string? _values;
    internal ReadOnlySpan<char> Value => _values.AsSpan();
#endif

    /// <summary>
    /// Searches for the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns><c>true</c> if <paramref name="value"/> was found; otherwise, <c>false</c>.</returns>
    public bool Contains(char value) => Value.Contains(value);
}

