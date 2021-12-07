﻿using System.Buffers;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Simuliert statische Methoden der <see cref="string"/>-Klasse zum Erzeugen von <see cref="string"/>s für .NET-Versionen, in denen diese nicht verfügbar sind.
    /// </summary>
    [Obsolete("Use the StaticStringMethod class instead.", true)]
    public static class StringCreator
    {

        //#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Erstellt eine neue Zeichenfolge mit einer bestimmten Länge und initialisiert sie nach der Erstellung unter Verwendung des angegebenen Rückrufs.
        /// </summary>
        /// <typeparam name="TState">Der Typ des Elements, das an <paramref name="action"/> übergeben werden soll.</typeparam>
        /// <param name="length">Die Länge der zu erstellenden Zeichenfolge.</param>
        /// <param name="state">Das an <paramref name="action"/> zu übergebende Element.</param>
        /// <param name="action">Ein Rückruf zum Initialisieren der Zeichenfolge.</param>
        /// <returns>Die erstellte Zeichenfolge.</returns>
        /// <remarks>Die Methode simuliert die statische Methode String.Create&lt;TState&gt;(int, TState, SpanAction&lt;char,TState&gt;).
        /// In neueren .NET-Versionen wird der Aufruf direkt an die vorhandene Methode der <see cref="string"/>-Klasse weitergeleitet. In 
        /// .NET Framework und .NET Standard 2.0 ermöglicht die Simulation zumindest bei der Erstellung kurzer <see cref="string"/>s, mit 
        /// nur einer Heap-Allokation auszukommen.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> ist negativ.</exception>
        public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
            => StaticStringMethod.Create(length, state, action);

    }
}
