#if !NET40
using System;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;char&gt;</see>-Struktur.
    /// <note type="note">
    /// Die Klasse ist für .NET-Framework 4.0 nicht verfügbar.
    /// </note>
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static class ReadOnlySpanExtensions
    {
        /// <summary>
        /// Gibt bei jedem Aufruf denselben Hashcode für eine identische Zeichenfolge zurück.
        /// <note type="note">
        /// Die Methode ist für .NET-Framework 4.0 nicht verfügbar.
        /// </note>
        /// </summary>
        /// <param name="span">Die zu hashende Zeichenfolge.</param>
        /// <param name="hashType">Die Art des zu erzeugenden Hashcodes.</param>
        /// <returns>Der Hashcode.</returns>
        /// <remarks>
        /// <para>
        /// Der von dieser Methode erzeugte Hashcode ist nicht identisch mit dem Hashcode, der von .NET-Framework 4.0
        /// erzeugt wird, denn 
        /// er verwendet Roundshifting, um mehr Information zu bewahren. 
        /// </para>
        /// <para>Die mit unterschiedlichen Werten für <paramref name="hashType"/> erzeugten Hashcodes können
        /// für eine identische Zeichenfolge verschiedene Hashcodes liefern und dürfen deshalb nicht vermischt werden.</para>
        /// <para>
        /// Verwenden Sie die von der Methode erzeugten Hashcodes nicht in 
        /// sicherheitskritischen Anwendungen (wie z.B. dem Hashen von Passwörtern)!
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="hashType"/> ist kein definierter Wert der <see cref="HashType"/>-Enum.</exception>
        public static int GetStableHashCode(this ReadOnlySpan<char> span, HashType hashType)
        {
            return hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(span),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(span),
                HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericNoCase(span),
                _ => throw new ArgumentOutOfRangeException(nameof(hashType))
            };
        }



        private static int GetHashCodeOrdinal(ReadOnlySpan<char> span)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < span.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ span[i];
                    if (i == span.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ span[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }


        private static int GetHashCodeOrdinalIgnoreCase(ReadOnlySpan<char> span)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < span.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(span[i]);
                    if (i == span.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ char.ToUpperInvariant(span[i + 1]);
                }

                return hash1 + (hash2 * 1566083941);
            }
        }


        private static int GetHashCodeAlphaNumericNoCase(ReadOnlySpan<char> span)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < span.Length;)
                {
                    for (; i < span.Length; i++)
                    {
                        char current = span[i];

                        if (char.IsLetterOrDigit(current))
                        {
                            hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(current);
                            i++;

                            // Hashe nächstes Zeichen:
                            for (; i < span.Length; i++)
                            {
                                char next = span[i];

                                if (char.IsLetterOrDigit(next))
                                {
                                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ char.ToUpperInvariant(next);
                                    i++;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
#endif
