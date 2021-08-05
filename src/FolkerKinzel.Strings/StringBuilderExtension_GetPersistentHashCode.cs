using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="StringBuilder"/>-Klasse.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static partial class StringBuilderExtension
    {
        /// <summary>
        /// Erzeugt bei jedem Programmlauf denselben <see cref="int"/>-Hashcode für eine identische Zeichenfolge.
        /// </summary>
        /// <param name="builder">Die zu hashende Zeichenfolge.</param>
        /// <param name="hashType">Die Art des zu erzeugenden Hashcodes.</param>
        /// <returns>Der Hashcode.</returns>
        /// <remarks>
        /// <para>
        /// Die Methode <see cref="string.GetHashCode()">String.GetHashCode()</see> gibt aus Sicherheitsgründen bei jedem Programmlauf 
        /// einen unterschiedlichen
        /// Hashcode für eine identische Zeichenfolge zurück. Abgesehen davon, dass auch der Hash-Algorithmus von 
        /// <see cref="string.GetHashCode()">String.GetHashCode()</see> in unterschiedlichen Frameworkversionen unterschiedlich sein könnte, 
        /// macht es schon deshalb keinen
        /// Sinn, den Rückgabewert von <see cref="string.GetHashCode()"/> für die Wiederverwendung zu speichern. Die Alternativen, z.B.
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
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="hashType"/> ist kein 
        /// definierter Wert der <see cref="HashType"/>-Enum.</exception>
        /// <example>
        /// <code language="cs" source="..\Examples\Example.cs"/>
        /// </example>
        public static int GetPersistentHashCode(this StringBuilder builder, HashType hashType)
        {
            return builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : (hashType switch
                {
                    HashType.Ordinal => GetHashCodeOrdinal(builder),
                    HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(builder),
                    HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericIgnoreCase(builder),
                    _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType))
                });
        }



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

        #endregion

    }
}
