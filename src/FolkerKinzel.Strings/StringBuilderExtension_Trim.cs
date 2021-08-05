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
        #region Trim

        /// <summary>
        /// Entfernt alle führenden und nachgestellten Leerraumzeichen aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder Trim(this StringBuilder builder)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd().DoTrimStart();


        /// <summary>
        /// Entfernt alle führenden und nachgestellten Instanzen eines Zeichens aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChar">Ein zu entfernendes Unicode-Zeichen.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder Trim(this StringBuilder builder, char trimChar)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd(trimChar).DoTrimStart(trimChar);


        /// <summary>
        /// Entfernt alle führenden und nachgestellten Vorkommen der Zeichen im angegebenen Array aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Ein Array mit den zu entfernenden Unicode-Zeichen oder <c>null</c>. Wenn <paramref name="trimChars"/>&#160;<c>null</c>
        /// oder ein leeres Array ist, werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder Trim(this StringBuilder builder, params char[]? trimChars)
           => builder is null
               ? throw new ArgumentNullException(nameof(builder))
               : trimChars is null || trimChars.Length == 0
                   ? builder.DoTrimEnd().DoTrimStart()
                   : builder.DoTrimEnd(trimChars).DoTrimStart(trimChars);


        /// <summary>
        /// Entfernt alle führenden und nachgestellten Vorkommen der Zeichen in der angegebenen Spanne aus dem <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder Trim(this StringBuilder builder, ReadOnlySpan<char> trimChars)
           => builder is null
               ? throw new ArgumentNullException(nameof(builder))
               : trimChars.Length == 0
                   ? builder.DoTrimEnd().DoTrimStart()
                   : builder.DoTrimEnd(trimChars).DoTrimStart(trimChars);

        #endregion

    }
}
