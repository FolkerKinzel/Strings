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
        /// Gibt an, ob ein angegebener Wert in einem <see cref="ReadOnlySpan{T}"/> gefunden wird. 
        /// Werte werden mit „IEquatable{T}.Equals(T)“ verglichen.
        /// </summary>
        /// <typeparam name="T">Der Typ der Spanne.</typeparam>
        /// <param name="span">Die zu durchsuchende Spanne.</param>
        /// <param name="value">Der zu suchende Wert.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> gefunden wurde, andernfalls <c>false</c>.</returns>
        /// <remarks>Verfügbar für .NET Framework 4.5, .NET Standard 2.0 und .NET Standard 2.1.</remarks>
        public static bool Contains<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
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
