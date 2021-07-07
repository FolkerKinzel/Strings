using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;


namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="string"/>-Klasse.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static partial class StringExtension
    {
        /// <summary>
        /// Obsolete.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        [Obsolete("Use GetPersistentHashCode instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public static int GetStableHashCode(this string s, HashType hashType)
            => GetPersistentHashCode(s, hashType);

        /// <summary>
        /// Erzeugt bei jedem Programmlauf denselben <see cref="int"/>-Hashcode für eine identische Zeichenfolge.
        /// </summary>
        /// <param name="s">Die zu hashende Zeichenfolge.</param>
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
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="hashType"/> ist kein 
        /// definierter Wert der <see cref="HashType"/>-Enum.</exception>
        /// <example>
        /// <code language="cs" source="..\Examples\Example.cs"/>
        /// </example>
        public static int GetPersistentHashCode(this string s, HashType hashType)
            => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().GetPersistentHashCode(hashType);


        /// <summary>
        /// Erzeugt einen <see cref="string"/>, aus dem alle führenden und nachgestellten Vorkommen der Zeichen in der angegebenen Spanne entfernt sind.
        /// </summary>
        /// <param name="s">Die zu untersuchende Zeichenfolge.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Die resultierende Zeichenfolge, nachdem alle im <paramref name="trimChars"/>-Parameter übergebenen Zeichen am Anfang und Ende der 
        /// Zeichenfolge entfernt wurden. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        public static string Trim(this string s, ReadOnlySpan<char> trimChars)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (trimChars.Length == 0)
            {
                return s.Trim();
            }

            ReadOnlySpan<char> span = s.AsSpan().DoTrimEnd(trimChars).DoTrimStart(trimChars);

            return span.Length == s.Length
                ? s
                : span.Length == 0
                    ? string.Empty
                    : span.ToString();
        }

        /// <summary>
        /// Erzeugt einen <see cref="string"/>, aus dem alle führenden Vorkommen der Zeichen in der angegebenen Spanne entfernt sind.
        /// </summary>
        /// <param name="s">Die zu untersuchende Zeichenfolge.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Die resultierende Zeichenfolge, nachdem alle im <paramref name="trimChars"/>-Parameter übergebenen Zeichen am Anfang der 
        /// Zeichenfolge entfernt wurden. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        public static string TrimStart(this string s, ReadOnlySpan<char> trimChars)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (trimChars.Length == 0)
            {
                return s.TrimStart();
            }

            ReadOnlySpan<char> span = s.AsSpan().DoTrimStart(trimChars);

            return span.Length == s.Length
                ? s
                : span.Length == 0
                    ? string.Empty
                    : span.ToString();
        }

        /// <summary>
        /// Erzeugt einen <see cref="string"/>, aus dem alle nachgestellten Vorkommen der Zeichen in der angegebenen Spanne entfernt sind.
        /// </summary>
        /// <param name="s">Die zu untersuchende Zeichenfolge.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Die resultierende Zeichenfolge, nachdem alle im <paramref name="trimChars"/>-Parameter übergebenen Zeichen am Ende der 
        /// Zeichenfolge entfernt wurden. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (trimChars.Length == 0)
            {
                return s.TrimEnd();
            }

            ReadOnlySpan<char> span = s.AsSpan().DoTrimEnd(trimChars);

            return span.Length == s.Length
                ? s
                : span.Length == 0
                    ? string.Empty
                    : span.ToString();
        }

        private static ReadOnlySpan<char> DoTrimEnd(this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
        {
            int length = span.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (trimChars.Contains(span[i]))
                {
                    --length;  
                }
                else
                {
                    break;
                }
            }

            return span.Slice(0, length);
        }
        

        private static ReadOnlySpan<char> DoTrimStart(this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
        {
            int length = span.Length;

            for (int j = 0; j < length; j++)
            {
                if (trimChars.Contains(span[j]))
                {
                    continue;
                }
                else
                {
                    return span.Slice(j);
                }
            }

            return ReadOnlySpan<char>.Empty;
        }
    }
}
