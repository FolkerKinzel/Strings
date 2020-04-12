using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Gibt bei jedem Aufruf denselben Hashcode für einen identischen <see cref="StringBuilder"/> zurück. 
        /// Erzeugt den identischen Hash wie <see cref="StringExtensions.GetStableHashCode(string, HashType)"/>.
        /// </summary>
        /// <param name="sb">Der zu hashende <see cref="StringBuilder"/>.</param>
        /// <param name="hashType">Die Art des zu erzeugenden Hashcodes.</param>
        /// <returns>Der Hashcode für <paramref name="sb"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="hashType"/> ist kein definierter Wert der <see cref="HashType"/>-Enum.</exception>
        public static int GetStableHashCode(this StringBuilder sb, HashType hashType)
        {
            if (sb is null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            return hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(sb),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(sb),
                HashType.AlphaNumericNoCase => GetHashCodeAlphaNumericNoCase(sb),
                _ => throw new ArgumentOutOfRangeException(nameof(hashType))
            };
        }


        /// <summary>
        /// Erzeugt einen Hashcode mit exaktem Zeichenvergleich.
        /// </summary>
        /// <param name="str">Der zu hashende <see cref="string"/>.</param>
        /// <returns>Der Hashcode.</returns>
        private static int GetHashCodeOrdinal(StringBuilder str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ str[i];
                    if (i == str.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        /// <summary>
        /// Erzeugt einen Hashcode, der die Groß- und Kleinschreibung unberücksichtigt lässt.
        /// </summary>
        /// <param name="str">Der zu hashende <see cref="string"/>.</param>
        /// <returns>Der Hashcode.</returns>
        private static int GetHashCodeOrdinalIgnoreCase(StringBuilder str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ Char.ToUpperInvariant(str[i]);
                    if (i == str.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ Char.ToUpperInvariant(str[i + 1]);
                }

                return hash1 + (hash2 * 1566083941);
            }
        }


        private static int GetHashCodeAlphaNumericNoCase(StringBuilder str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length;)
                {
                    for (; i < str.Length; i++)
                    {
                        char current = str[i];

                        if (char.IsLetterOrDigit(current))
                        {
                            hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ Char.ToUpperInvariant(current);
                            i++;

                            // Hashe nächstes Zeichen:
                            for (; i < str.Length; i++)
                            {
                                char next = str[i];

                                if (char.IsLetterOrDigit(next))
                                {
                                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ Char.ToUpperInvariant(next);
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
