using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only character span contains a newline character.</summary>
    /// <param name="span">The span to search.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains a newline character, otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsNewLine(this ReadOnlySpan<char> span)
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
#pragma warning disable CA1303 // Do not pass literals as localized parameters
        => span.IndexOfAny(SearchValuesStorage.NEW_LINE_CHARS.AsSpan()) != -1;
#pragma warning restore CA1303 // Do not pass literals as localized parameters
#else
        => span.IndexOfAny(SearchValuesStorage.NewLineChars) != -1;
#endif
    //{
    //    for (int i = 0; i < span.Length; i++)
    //    {
    //        if (span[i].IsNewLine())
    //        {
    //            return true;
    //        }
    //    }

    //    return false;
    //}
}
