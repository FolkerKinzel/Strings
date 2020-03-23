using System;
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
        /// <param name="ignoreCase"><c>true</c>, um einen Hashcode zu erzeugen, der die Groß- und Kleinschreibung ignoriert.</param>
        /// <returns>Der Hashcode für <paramref name="s"/>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>Die Erweiterungsmethode basiert auf einer Arbeit von Andrew Lock
        /// ( https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/ ).
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Argumente von öffentlichen Methoden validieren", Justification = "<Ausstehend>")]
        public static int GetStableHashCode(this string s, bool ignoreCase = false)
        {
            if(s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return ignoreCase ? GetHashCodeOrdinalIgnoreCase(s) : GetHashCodeOrdinal(s);
        }


        /// <summary>
        /// Erzeugt einen Hashcode mit exaktem Zeichenvergleich.
        /// </summary>
        /// <param name="str">Der zu hashende <see cref="string"/>.</param>
        /// <returns>Der Hashcode.</returns>
        /// <remarks>Das Original stammt von 
        /// https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/ .
        /// </remarks>
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static int GetHashCodeOrdinal(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        /// <summary>
        /// Erzeugt einen Hashcode, der die Groß- und Kleinschreibung unberücksichtigt lässt.
        /// </summary>
        /// <param name="str">Der zu hashende <see cref="string"/>.</param>
        /// <returns>Der Hashcode.</returns>
        /// <remarks>Das Original stammt von 
        /// https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/ .
        /// </remarks>
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static int GetHashCodeOrdinalIgnoreCase(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ Char.ToUpperInvariant(str[i]);
                    if (i == str.Length - 1)
                    {
                        break;
                    }
                    hash2 = ((hash2 << 5) + hash2) ^ Char.ToUpperInvariant(str[i + 1]);
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
