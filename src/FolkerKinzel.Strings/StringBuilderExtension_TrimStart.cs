using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class StringBuilderExtension
    {
        #region TrimStart

        /// <summary>
        /// Entfernt alle führenden Leerraumzeichen aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimStart(this StringBuilder builder)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimStart();

        /// <summary>
        /// Entfernt alle führenden Instanzen eines Zeichens aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChar">Ein zu entfernendes Unicode-Zeichen.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimStart(this StringBuilder builder, char trimChar)
           => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimStart(trimChar);

        /// <summary>
        /// Entfernt alle führenden Vorkommen der Zeichen im angegebenen Array aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Ein Array mit den zu entfernenden Unicode-Zeichen oder <c>null</c>. Wenn 
        /// <paramref name="trimChars"/>&#160;<c>null</c>
        /// oder ein leeres Array ist, werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimStart(this StringBuilder builder, params char[]? trimChars)
           => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : trimChars is null || trimChars.Length == 0
                    ? builder.DoTrimStart()
                    : builder.DoTrimStart(trimChars);

        /// <summary>
        /// Entfernt alle führenden Vorkommen der Zeichen in der angegebenen Spanne aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen oder <c>null</c>. Wenn 
        /// <paramref name="trimChars"/> eine leere Spanne ist, werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder TrimStart(this StringBuilder builder, ReadOnlySpan<char> trimChars)
           => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : trimChars.Length == 0
                    ? builder.DoTrimStart()
                    : builder.DoTrimStart(trimChars);


        #endregion

        #region private Methods

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
                if (trimChar == stringBuilder[j])
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
