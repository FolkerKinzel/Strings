using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="StringBuilder"/>-Klasse.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static class StringBuilderExtension
    {
        [Obsolete("Use GetPersistentHashCode instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public static int GetStableHashCode(this StringBuilder sb, HashType hashType)
            => GetPersistentHashCode(sb, hashType);

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
        /// <exception cref="ArgumentException"><paramref name="hashType"/> ist kein 
        /// definierter Wert der <see cref="HashType"/>-Enum.</exception>
        /// <example>
        /// <code language="cs" source="..\Examples\Example.cs"/>
        /// </example>
        public static int GetPersistentHashCode(this StringBuilder sb, HashType hashType)
        {
            return sb is null
                ? throw new ArgumentNullException(nameof(sb))
                : (hashType switch
                {
                    HashType.Ordinal => GetHashCodeOrdinal(sb),
                    HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(sb),
                    HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericIgnoreCase(sb),
                    _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType))
                });
        }

        #region TrimEnd

        public static StringBuilder TrimEnd(this StringBuilder stringBuilder)
            => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimEnd();


        public static StringBuilder TrimEnd(this StringBuilder stringBuilder, char trimChar)
            => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimEnd(trimChar);


        public static StringBuilder TrimEnd(this StringBuilder stringBuilder, params char[]? trimChars)
        {
            return stringBuilder is null
                ? throw new ArgumentNullException(nameof(stringBuilder))
                : trimChars is null || trimChars.Length == 0
                    ? stringBuilder.DoTrimEnd()
                    : stringBuilder.DoTrimEnd(trimChars);
        }

        #endregion

        #region TrimStart

        public static StringBuilder TrimStart(this StringBuilder stringBuilder)
            => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimStart();

        public static StringBuilder TrimStart(this StringBuilder stringBuilder, char trimChar)
           => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimStart(trimChar);

        public static StringBuilder TrimStart(this StringBuilder stringBuilder, params char[]? trimChars)
           => stringBuilder is null
                ? throw new ArgumentNullException(nameof(stringBuilder))
                : trimChars is null || trimChars.Length == 0
                    ? stringBuilder.DoTrimEnd()
                    : stringBuilder.DoTrimEnd(trimChars);

        #endregion

        #region Trim

        public static StringBuilder Trim(this StringBuilder stringBuilder)
            => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimEnd().DoTrimStart();


        public static StringBuilder Trim(this StringBuilder stringBuilder, char trimChar)
            => stringBuilder is null ? throw new ArgumentNullException(nameof(stringBuilder)) : stringBuilder.DoTrimEnd(trimChar).DoTrimStart(trimChar);


        public static StringBuilder Trim(this StringBuilder stringBuilder, params char[]? trimChars)
           => stringBuilder is null
               ? throw new ArgumentNullException(nameof(stringBuilder))
               : trimChars is null || trimChars.Length == 0
                   ? stringBuilder.DoTrimEnd().DoTrimStart()
                   : stringBuilder.DoTrimEnd(trimChars).DoTrimStart(trimChars);

        #endregion

        #region private Methods

        #region GetHashCode

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

        #endregion

        #region DoTrimEnd

        private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder)
        {
            int length = stringBuilder.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(stringBuilder[i]))
                {
                    --length;
                }
                else
                {
                    break;
                }
            }

            stringBuilder.Length = length;
            return stringBuilder;
        }


        private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder, char trimChar)
        {
            int length = stringBuilder.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (trimChar.Equals(stringBuilder[i]))
                {
                    --length;
                }
                else
                {
                    break;
                }
            }

            stringBuilder.Length = length;
            return stringBuilder;
        }


        private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder, ReadOnlySpan<char> trimChars)
        {
            int length = stringBuilder.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (trimChars.Contains(stringBuilder[i]))
                {
                    --length;
                }
                else
                {
                    break;
                }
            }

            stringBuilder.Length = length;
            return stringBuilder;
        }

        #endregion

        #region DoTrimStart

        private static StringBuilder DoTrimStart(this StringBuilder stringBuilder)
        {
            int length = stringBuilder.Length;

            for (int j = 0; j < length; j++)
            {
                if (char.IsWhiteSpace(stringBuilder[j]))
                {
                    continue;
                }
                else
                {
                    return stringBuilder.Remove(0, j);
                }
            }

            return stringBuilder.Clear();
        }




        private static StringBuilder DoTrimStart(this StringBuilder stringBuilder, char trimChar)
        {
            int length = stringBuilder.Length;

            for (int j = 0; j < length; j++)
            {
                if (trimChar.Equals(stringBuilder[j]))
                {
                    continue;
                }
                else
                {
                    return stringBuilder.Remove(0, j);
                }
            }

            return stringBuilder.Clear();
        }



        private static StringBuilder DoTrimStart(this StringBuilder stringBuilder, ReadOnlySpan<char> trimChars)
        {
            int length = stringBuilder.Length;

            for (int j = 0; j < length; j++)
            {
                if (trimChars.Contains(stringBuilder[j]))
                {
                    continue;
                }
                else
                {
                    return stringBuilder.Remove(0, j);
                }
            }

            return stringBuilder.Clear();
        }

        #endregion

        #endregion

    }
}
