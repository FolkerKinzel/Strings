using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Intls;

internal static class SearchValuesStorage
{
    /// <summary>
    /// The Unicode Standard, Sec. 5.8, Recommendation R4 and Table 5-2 state that the CR, LF,
    /// CRLF, NEL, LS, FF, and PS sequences are considered newline functions. That section
    /// also specifically excludes VT from the list of newline functions, so we do not include
    /// it in the needle list.
    /// </summary>
    internal const string NEW_LINE_CHARS = "\n\r\f\u0085\u2028\u2029";

    /// <summary>
    /// SearchValues for new line chars.
    /// </summary>
    /// <remarks>
    /// The Unicode Standard, Sec. 5.8, Recommendation R4 and Table 5-2 state that the CR, LF,
    /// CRLF, NEL, LS, FF, and PS sequences are considered newline functions. That section
    /// also specifically excludes VT from the list of newline functions, so we do not include
    /// it in the needle list.
    /// </remarks>
    internal static readonly SearchValues<char> NewLineChars = SearchValues.Create(NEW_LINE_CHARS);
}
