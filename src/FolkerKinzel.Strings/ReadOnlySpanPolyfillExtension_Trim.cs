namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0

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
    public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, string? trimChars)
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
    public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, string? trimChars)
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
    public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, string? trimChars)
        => span.TrimEnd(trimChars.AsSpan());

#endif
}
