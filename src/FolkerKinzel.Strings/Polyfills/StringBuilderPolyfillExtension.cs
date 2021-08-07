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
#if NET45 || NETSTANDARD2_0

        //public static StringBuilder Append(this StringBuilder builder, StringBuilder? value)
        //    => builder is null
        //            ? throw new NullReferenceException()
        //            : value is null
        //                    ? builder 
        //                    : builder.Append(value, 0, value.Length);


        /// <summary>
        /// Fügt eine Kopie einer Teilzeichenfolge im festgelegten <see cref="StringBuilder"/> an diese Instanz an.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
#endif
    }
}
