using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>-Struktur.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static partial class ReadOnlySpanExtension
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


    }
}
