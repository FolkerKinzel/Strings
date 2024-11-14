using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
    /// <summary>Replaces all newlines in <paramref name="s" /> with 
    /// <see cref="Environment.NewLine" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of 
    /// <paramref name="s" />, but with all newline sequences replaced with 
    /// <see cref="Environment.NewLine" />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(). The method
    /// should therefore only be used in the extension method syntax. It throws a 
    /// <see cref="NullReferenceException" /> if <paramref name="s" /> is <c>null</c> in order 
    /// to show identical behavior to the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and canonicalizes
    /// them to match the newline sequence for the current environment. For example, when
    /// running on Windows, all occurrences of non-Windows Newline sequences are replaced
    /// with the sequence CRLF. When running on Unix, all occurrences of non-Unix Newline
    /// sequences are replaced with a single LF character.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(this string s)
        => s.ReplaceLineEndings(Environment.NewLine);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(string s)
            => s.ReplaceLineEndings();
#endif

    /// <summary>Replaces all newlines in <paramref name="s" /> with 
    /// <paramref name="replacementText" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="replacementText">The text to use as replacement. If 
    /// <paramref name="replacementText" /> is <see cref="string.Empty" />, all newline 
    /// sequences within <paramref name="s" /> will be removed.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of 
    /// <paramref name="s" />, but with all newline sequences replaced with 
    /// <paramref name="replacementText" />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(String). The
    /// method should therefore only be used in the extension method syntax. It throws a
    /// <see cref="NullReferenceException" /> if <paramref name="s" /> is <c>null</c> in
    /// order to show identical behavior to the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and 
    /// canonicalizes them to match <paramref name="replacementText" />.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="replacementText" /> is <c>null</c>.
    /// </exception>
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0
    public static string ReplaceLineEndings(this string s, string replacementText)
    {
        _NullReferenceException.ThrowIfNull(s, nameof(s));
        _ArgumentNullException.ThrowIfNull(replacementText, nameof(replacementText));

        ReadOnlySpan<char> inputSpan = s.AsSpan();

        int firstIdx = inputSpan.IndexOfAny(SearchValuesStorage.NewLineChars);

        if (firstIdx == -1)
        {
            return s;
        }

        int lastIdx = inputSpan.LastIndexOfAny(SearchValuesStorage.NewLineChars);
        ReadOnlySpan<char> processedSpan = inputSpan.Slice(firstIdx, lastIdx + 1 - firstIdx);

        int capacity = ComputeMaxCapacity(processedSpan.Length, replacementText.Length);

        if (capacity > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
            int outLength = processedSpan.ReplaceLineEndings(replacementText.AsSpan(), buf.Array);
            Span<char> outSpan = buf.Array.AsSpan(0, outLength);
            return processedSpan.Equals(outSpan, StringComparison.Ordinal)
                ? s
                : StaticStringMethod.Concat(inputSpan.Slice(0, firstIdx), outSpan, inputSpan.Slice(lastIdx + 1));
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = processedSpan.ReplaceLineEndings(replacementText.AsSpan(), destination);
            Span<char> outSpan = destination.Slice(0, outLength);
            return processedSpan.Equals(outSpan, StringComparison.Ordinal)
                ? s
                : StaticStringMethod.Concat(inputSpan.Slice(0, firstIdx), outSpan, inputSpan.Slice(lastIdx + 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        => sourceLength * Math.Max(1, replacementLength);
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(string s, string replacementText)
        => s.ReplaceLineEndings(replacementText);
#endif

}



