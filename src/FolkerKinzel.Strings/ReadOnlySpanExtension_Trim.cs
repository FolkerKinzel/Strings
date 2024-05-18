using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, SearchValues<char> trimValues)
        => span.TrimStart(trimValues).TrimEnd(trimValues);


    public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, SearchValues<char> trimValues)
    {
        int idx = span.IndexOfAnyExcept(trimValues);
        return idx == -1 ? [] : span.Slice(idx);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, SearchValues<char> trimValues)
        => span.Slice(0, span.LastIndexOfAnyExcept(trimValues) + 1);



}


