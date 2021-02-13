using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="StringBuilder"/>-Klasse.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Gibt bei jedem Aufruf denselben Hashcode für eine identische Zeichenfolge zurück.
        /// </summary>
        /// <param name="sb">Die zu hashende Zeichenfolge.</param>
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
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="hashType"/> ist kein definierter Wert der <see cref="HashType"/>-Enum.</exception>
        public static int GetStableHashCode(this StringBuilder sb, HashType hashType)
        {
            return sb is null
                ? throw new ArgumentNullException(nameof(sb))
                : (hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(sb),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(sb),
                HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericIgnoreCase(sb),
                _ => throw new ArgumentOutOfRangeException(nameof(hashType))
            });
        }


        
        private static int GetHashCodeOrdinal(StringBuilder sb)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < sb.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ sb[i];
                    if (i == sb.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ sb[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        
        private static int GetHashCodeOrdinalIgnoreCase(StringBuilder sb)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < sb.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(sb[i]);
                    if (i == sb.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ char.ToUpperInvariant(sb[i + 1]);
                }

                return hash1 + (hash2 * 1566083941);
            }
        }


        private static int GetHashCodeAlphaNumericIgnoreCase(StringBuilder sb)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < sb.Length;)
                {
                    for (; i < sb.Length; i++)
                    {
                        char current = sb[i];

                        if (char.IsLetterOrDigit(current))
                        {
                            hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(current);
                            i++;

                            // Hashe nächstes Zeichen:
                            for (; i < sb.Length; i++)
                            {
                                char next = sb[i];

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
