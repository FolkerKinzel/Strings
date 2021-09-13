using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        public static int LastIndexOf (this ReadOnlySpan<char> span, ReadOnlySpan<char> value, int startIndex, int count, StringComparison comparisonType)
        {
            int matchIndex = span.Slice(startIndex - count + 1, count).LastIndexOf(value, comparisonType);
            return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
        }
        

    }
}
