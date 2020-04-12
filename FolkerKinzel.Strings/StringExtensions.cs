﻿using System;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings
{

    /// <summary>
    /// Erweiterungsmethoden für die <see cref="string"/>-Klasse.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gibt bei jedem Aufruf denselben Hashcode für einen identischen <see cref="string"/> zurück.
        /// </summary>
        /// <param name="s">Der zu hashende <see cref="string"/>.</param>
        /// <param name="hashType">Die Art des zu erzeugenden Hashcodes.</param>
        /// <returns>Der Hashcode für <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="hashType"/> ist kein definierter Wert der <see cref="HashType"/>-Enum.</exception>
        public static int GetStableHashCode(this string s, HashType hashType)
        {
            if(s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(s),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(s),
                HashType.AlphaNumericNoCase => GetHashCodeAlphaNumericNoCase(s),
                _ => throw new ArgumentOutOfRangeException(nameof(hashType))
            };
        }


        /// <summary>
        /// Erzeugt einen Hashcode mit exaktem Zeichenvergleich.
        /// </summary>
        /// <param name="str">Der zu hashende <see cref="string"/>.</param>
        /// <returns>Der Hashcode.</returns>
        private static int GetHashCodeOrdinal(string str)
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
        private static int GetHashCodeOrdinalIgnoreCase(string str)
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


        private static int GetHashCodeAlphaNumericNoCase(string str)
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

                        if(char.IsLetterOrDigit(current))
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
