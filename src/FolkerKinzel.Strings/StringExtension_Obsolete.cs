using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

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


    }
}
