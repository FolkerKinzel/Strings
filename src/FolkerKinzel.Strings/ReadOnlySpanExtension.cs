#if !NET40
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>-Struktur.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static class ReadOnlySpanExtension
    {
        /// <summary>
        /// Obsolete.
        /// </summary>
        /// <param name="span"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        [Obsolete("Use GetPersistentHashCode instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public static int GetStableHashCode(this ReadOnlySpan<char> span, HashType hashType)
            => GetPersistentHashCode(span, hashType);

        /// <summary>
        /// Erzeugt bei jedem Programmlauf denselben <see cref="int"/>-Hashcode für eine identische Zeichenfolge.
        /// </summary>
        /// <param name="span">Die zu hashende Zeichenfolge.</param>
        /// <param name="hashType">Die Art des zu erzeugenden Hashcodes.</param>
        /// <returns>Der Hashcode.</returns>
        /// <remarks>
        /// <para>
        /// Die Methode <see cref="string.GetHashCode">String.GetHashCode()</see> gibt aus Sicherheitsgründen bei jedem Programmlauf 
        /// einen unterschiedlichen
        /// Hashcode für eine identische Zeichenfolge zurück. Abgesehen davon, dass auch der Hash-Algorithmus von 
        /// <see cref="string.GetHashCode">String.GetHashCode()</see> in unterschiedlichen Frameworkversionen unterschiedlich sein könnte, 
        /// macht es schon deshalb keinen
        /// Sinn, den Rückgabewert von <see cref="string.GetHashCode"/> für die Wiederverwendung zu speichern. Die Alternativen, z.B.
        /// <see cref="MD5"/> oder <see cref="SHA256"/>, verbrauchen mehr Speicherplatz und sind langsamer. So bietet diese Methode eine
        /// schlanke Alternative, die sich zum Hashen sehr kurzer Zeichenfolgen eignet, die nicht in einem sicherheitskritischen Zusammenhang 
        /// verwendet werden.
        /// </para>
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
        /// <exception cref="ArgumentException"><paramref name="hashType"/> ist kein 
        /// definierter Wert der <see cref="HashType"/>-Enum.</exception>
        /// <example>
        /// <code language="cs" source="..\Examples\Example.cs"/>
        /// </example>
        public static int GetPersistentHashCode(this ReadOnlySpan<char> span, HashType hashType)
        {
            return hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(span),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(span),
                HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericNoCase(span),
                _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType))
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
