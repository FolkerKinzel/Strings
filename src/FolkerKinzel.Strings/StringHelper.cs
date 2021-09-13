using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Simuliert statische Methoden der <see cref="string"/>-Klasse für .NET-Versionen, in denen diese nicht verfügbar sind.
    /// </summary>
    public static class StringHelper
    {

#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Erstellt eine neue Zeichenfolge mit einer bestimmten Länge und initialisiert sie nach der Erstellung unter Verwendung des angegebenen Rückrufs.
        /// </summary>
        /// <typeparam name="TState">Der Typ des Elements, das an <paramref name="action"/> übergeben werden soll.</typeparam>
        /// <param name="length">Die Länge der zu erstellenden Zeichenfolge.</param>
        /// <param name="state">Das an <paramref name="action"/> zu übergebende Element.</param>
        /// <param name="action">Ein Rückruf zum Initialisieren der Zeichenfolge.</param>
        /// <returns>Die erstellte Zeichenfolge.</returns>
        public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (length <= 0)
            {
                return length == 0 ? string.Empty : throw new ArgumentOutOfRangeException(nameof(length));
            }

            Span<char> span = length > Const.ShortString ? new char[length] : stackalloc char[length];
            action(span, state);
            return span.ToString();
        }
#else
        /// <summary>
        /// Erstellt eine neue Zeichenfolge mit einer bestimmten Länge und initialisiert sie nach der Erstellung unter Verwendung des angegebenen Rückrufs.
        /// </summary>
        /// <typeparam name="TState">Der Typ des Elements, das an <paramref name="action"/> übergeben werden soll.</typeparam>
        /// <param name="length">Die Länge der zu erstellenden Zeichenfolge.</param>
        /// <param name="state">Das an <paramref name="action"/> zu übergebende Element.</param>
        /// <param name="action">Ein Rückruf zum Initialisieren der Zeichenfolge.</param>
        /// <returns>Die erstellte Zeichenfolge.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
            => string.Create(length, state, action);
#endif
    }
}
