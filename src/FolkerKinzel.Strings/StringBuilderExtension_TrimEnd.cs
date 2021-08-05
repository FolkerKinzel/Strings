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
        #region TrimEnd

        /// <summary>
        /// Entfernt alle nachgestellten Leerraumzeichen aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimEnd(this StringBuilder builder)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd();


        /// <summary>
        /// Entfernt alle nachgestellten Instanzen eines Zeichens aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChar">Ein zu entfernendes Unicode-Zeichen.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimEnd(this StringBuilder builder, char trimChar)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd(trimChar);


        /// <summary>
        /// Entfernt alle nachgestellten Vorkommen der Zeichen im angegebenen Array aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Ein Array mit den zu entfernenden Unicode-Zeichen oder <c>null</c>. Wenn 
        /// <paramref name="trimChars"/>&#160;<c>null</c>
        /// oder ein leeres Array ist, werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimEnd(this StringBuilder builder, params char[]? trimChars)
        {
            return builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : trimChars is null || trimChars.Length == 0
                    ? builder.DoTrimEnd()
                    : builder.DoTrimEnd(trimChars);
        }


        /// <summary>
        /// Entfernt alle nachgestellten Vorkommen der Zeichen in der angegebenen Spanne aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn 
        /// <paramref name="trimChars"/> eine leere Spanne ist, werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars)
        {
            return builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : trimChars.Length == 0
                    ? builder.DoTrimEnd()
                    : builder.DoTrimEnd(trimChars);
        }

        #endregion

        #region private Methods

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
 
        #endregion

    }
}
