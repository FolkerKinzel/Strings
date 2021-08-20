using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gibt an, ob die schreibgeschütze Zeichenspanne ein Zeilenwechselzeichen enthält.
        /// </summary>
        /// <param name="span">Die zu durchsuchende Spanne.</param>
        /// <returns><c>true</c>, wenn <paramref name="span"/> ein Zeilenwechselzeichen enthält, andernfalls <c>false</c>.</returns>
        /// <remarks>Für den Vergleich wird <see cref="CharExtension.IsNewLine(char)"/> verwendet.</remarks>
        public static bool ContainsNewLine(this ReadOnlySpan<char> span)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if(span[i].IsNewLine())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
