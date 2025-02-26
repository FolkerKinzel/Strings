namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Removes all leading and trailing occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, string? trimChars)
#else
    public static ReadOnlySpan<char> Trim(ReadOnlySpan<char> span, string? trimChars)
#endif
        => span.Trim(trimChars.AsSpan());

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, string? trimChars)
#else
    public static ReadOnlySpan<char> TrimStart(ReadOnlySpan<char> span, string? trimChars)
#endif
        => span.TrimStart(trimChars.AsSpan());

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, string? trimChars)
#else
    public static ReadOnlySpan<char> TrimEnd(ReadOnlySpan<char> span, string? trimChars)
#endif
        => span.TrimEnd(trimChars.AsSpan());
}

