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
        
    }
}
