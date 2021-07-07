using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="ReadOnlySpan{T}"/>-Struktur, die in älteren .NET-Versionen als
    /// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
    /// </summary>
    public static class ReadOnlySpanPolyfillExtension
    {
#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1

        /// <summary>
        /// Gibt an, ob ein angegebenes Unicodezeichen in einer Spanne gefunden wird. 
        /// Werte werden mit <see cref="char.Equals(char)"/> verglichen.
        /// </summary>
        /// <param name="span">Die zu durchsuchende Spanne.</param>
        /// <param name="value">Das zu suchende Unicodezeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> gefunden wurde, andernfalls <c>false</c>.</returns>
        /// <remarks>Verfügbar für .NET Framework 4.5, .NET Standard 2.0 und .NET Standard 2.1.</remarks>
        public static bool Contains(this ReadOnlySpan<char> span, char value)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
#endif

        
    }
}
