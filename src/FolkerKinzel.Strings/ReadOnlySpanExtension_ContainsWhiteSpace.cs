using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gibt an, ob die schreibgeschütze Zeichenspanne ein Leerraumzeichen enthält.
        /// </summary>
        /// <param name="span">Die zu durchsuchende Spanne.</param>
        /// <returns><c>true</c>, wenn <paramref name="span"/> ein Leerraumzeichen enthält, anderenfalls <c>false</c>.</returns>
        /// <remarks>Für den Vergleich wird <see cref="char.IsWhiteSpace(char)"/> verwendet.</remarks>
        public static bool ContainsWhiteSpace(this ReadOnlySpan<char> span)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if(char.IsWhiteSpace(span[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
