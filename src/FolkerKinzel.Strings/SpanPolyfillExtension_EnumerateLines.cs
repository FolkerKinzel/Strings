using System.Text;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Returns an enumeration of lines over the provided span.
    /// </summary>
    /// <param name="span">A span containing the lines to enumerate.</param>
    /// <returns>An enumeration of lines.</returns>
    /// <remarks>
    /// <para>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0
    public static SpanLineEnumeratorPolyfill EnumerateLines(this Span<char> span)
#else
    public static SpanLineEnumeratorPolyfill EnumerateLines(Span<char> span)
#endif
        => new(span);
}

