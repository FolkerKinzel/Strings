using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings.Polyfills
{
    /// <summary>
    /// Erweiterungsmethoden, die als Polyfills für die Erweiterungsmethoden der Klasse <see cref="StringBuilderExtension"/>
    /// dienen.
    /// </summary>
    public static class StringBuilderExtensionPolyfillExtension
    {
#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Ersetzt in <paramref name="builder"/> alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <param name="replacement">Ein <see cref="string"/>, durch den die Leerzeichen-Sequenzen
        /// ersetzt werden, oder <c>null</c>, um alle Leerraumzeichen zu entfernen.</param>
        /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
        /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
        /// <remarks>
        /// <para>
        /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
        /// damit gründlicher als 
        /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
        /// </para>
        /// <para>
        /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
        /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
        /// </para>
        /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
        /// verwendet.)
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder ReplaceWhiteSpaceWith(
            this StringBuilder builder,
            string? replacement,
            bool skipNewLines = false)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), 0, builder.Length, skipNewLines);

        /// <summary>
        /// Ersetzt in einem Abschnitt von <paramref name="builder"/>, der bei <paramref name="startIndex"/> beginnt
        /// und bis zum Ende von <paramref name="builder"/> reicht, alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <param name="replacement">Ein <see cref="string"/>, durch den die Leerzeichen-Sequenzen
        /// ersetzt werden, oder <c>null</c>, um alle Leerraumzeichen zu entfernen.</param>
        /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
        /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem der Abschnitt beginnt,
        /// in dem die Ersetzungen vorgenommen werden.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
        /// <remarks>
        /// <para>
        /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
        /// damit gründlicher als 
        /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
        /// </para>
        /// <para>
        /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
        /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
        /// </para>
        /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
        /// verwendet.)
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> ist kleiner als 0 oder größer als die Anzahl der Zeichen in <paramref name="builder"/>.
        /// </exception>
        public static StringBuilder ReplaceWhiteSpaceWith(
            this StringBuilder builder,
            string? replacement,
            int startIndex,
            bool skipNewLines = false)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), startIndex, builder.Length - startIndex, skipNewLines);

        /// <summary>
        /// Ersetzt in einem Abschnitt von <paramref name="builder"/>, der bei <paramref name="startIndex"/> beginnt
        /// und <paramref name="count"/> Zeichen umfasst, alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <param name="replacement">Ein <see cref="string"/>, durch den die Leerzeichen-Sequenzen
        /// ersetzt werden, oder <c>null</c>, um alle Leerraumzeichen zu entfernen.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem der Abschnitt beginnt,
        /// in dem die Ersetzungen vorgenommen werden.</param>
        /// <param name="count">Die Länge des Abschnitts, in dem Ersetzungen vorgenommen werden.</param>
        /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
        /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
        /// <remarks>
        /// <para>
        /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
        /// damit gründlicher als 
        /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
        /// </para>
        /// <para>
        /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
        /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
        /// </para>
        /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
        /// verwendet.)
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="startIndex"/> oder <paramref name="count"/> ist kleiner als 0
        /// </para>
        /// <para>- oder -</para>
        /// <para>
        /// <paramref name="startIndex"/> + <paramref name="count"/>
        /// ist größer als die Anzahl der Zeichen in <paramref name="builder"/>.
        /// </para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringBuilder ReplaceWhiteSpaceWith(
            this StringBuilder builder,
            string? replacement,
            int startIndex,
            int count,
            bool skipNewLines = false)
        => builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), startIndex, count, skipNewLines);

#endif
    }
}
