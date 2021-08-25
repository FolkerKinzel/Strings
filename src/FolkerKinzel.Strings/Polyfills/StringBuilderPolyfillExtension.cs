using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FolkerKinzel.Strings.Polyfills
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="StringBuilder"/>-Klasse, die in .NET Framework 4.5 und .NET Standard 2.0 als
    /// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
    /// </summary>
    /// <remarks>
    /// Die Methoden dieser Klasse sollten ausschließlich in der Erweiterungsmethodensyntax verwendet zu werden, um die 
    /// in moderneren Frameworks vorhandenen Originalmethoden der <see cref="StringBuilder"/>-Klasse zu simulieren. Um dem Verhalten der 
    /// Originalmethoden zu entsprechen, werfen diese Erweiterungsmethoden eine <see cref="NullReferenceException"/>, wenn sie auf 
    /// <c>null</c> aufgerufen werden.
    /// </remarks>
    public static class StringBuilderPolyfillExtension
    {
        // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Fügt eine Kopie einer Teilzeichenfolge, die aus einem als Argument übergebenen <see cref="StringBuilder"/> stammt, an 
        /// den vorhandenen Inhalt von <paramref name="builder"/> an.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt geändert wird.</param>
        /// <param name="value">Der <see cref="StringBuilder"/>, von dessen Inhalt ein Teil kopiert wird.</param>
        /// <param name="startIndex">Der NULL-basierte Index in <paramref name="value"/>, an dem der zu kopierende
        /// Abschnitt beginnt.</param>
        /// <param name="count">Die Anzahl der zu kopierenden Zeichen.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="startIndex"/> oder <paramref name="count"/>
        /// sind kleiner als 0
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// die Summe <paramref name="startIndex"/> + <paramref name="count"/> ist größer als die Anzahl
        /// der Zeichen in <paramref name="value"/>.
        /// </para>
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> ist <c>null</c> und <paramref name="startIndex"/> oder <paramref name="count"/>
        /// haben einen Wert, der größer als 0 ist.
        /// </exception>
#if NETSTANDARD2_0
        [ExcludeFromCodeCoverage]
#endif
        public static StringBuilder Append(this StringBuilder builder, StringBuilder? value, int startIndex, int count)
        {
            if (builder is null)
            {
                throw new NullReferenceException();
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (value is null)
            {
                return startIndex == 0 && count == 0 ? builder : throw new ArgumentNullException(nameof(value));
            }

            if (count == 0)
            {
                return builder;
            }

            int length = startIndex + count;
            if (length > value.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            _ = builder.EnsureCapacity(builder.Length + count);


            for (int i = startIndex; i < length; i++)
            {
                _ = builder.Append(value[i]);
            }

            return builder;
        }


        /// <summary>
        /// Fügt die Zeichenfolgendarstellung eines festgelegten schreibgeschützten Zeichenspeicherbereichs an einen <see cref="StringBuilder"/> an.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, an den die Zeichen angefügt werden.</param>
        /// <param name="value">Der anzufügende schreibgeschützte Zeichenspeicherbereich.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
        /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
#if NETSTANDARD2_0
        [ExcludeFromCodeCoverage]
#endif
        public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value)
        {
            if (builder is null)
            {
                throw new NullReferenceException();
            }

            _ = builder.EnsureCapacity(builder.Length + value.Length);

            for (int i = 0; i < value.Length; i++)
            {
                _ = builder.Append(value[i]);
            }
            return builder;
        }

        /// <summary>
        /// Fügt den Inhalt einer schreibgeschützten Zeichenspanne an der angegebenen Zeichenposition in <paramref name="builder"/> ein.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, in den Zeichen eingefügt werden.</param>
        /// <param name="index">Der nullbasierte Index in <paramref name="builder"/>, an dem die Einfügung beginnt.</param>
        /// <param name="value">Die einzufügende Zeichenspanne.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Einfügevorgang abgeschlossen wurde.</returns>
        /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> ist kleiner als 0 oder größer
        /// als die Länge von <paramref name="builder"/>.</exception>
        public static StringBuilder Insert(this StringBuilder builder, int index, ReadOnlySpan<char> value)
        {
            if (builder is null)
            {
                throw new NullReferenceException();
            }

            if (index < 0 || index > builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _ = builder.EnsureCapacity(builder.Length + value.Length);

            for (int i = value.Length - 1; i >= 0; i--)
            {
                _ = builder.Insert(index, value[i]);
            }

            return builder;
        }

#endif
    }
}
