using System;
using System.Collections.Generic;
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
# if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Fügt die Zeichenfolgendarstellung eines festgelegten schreibgeschützten Zeichenspeicherbereichs an einen <see cref="StringBuilder"/> an.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, an den die Zeichen angefügt werden.</param>
        /// <param name="value">Der anzufügende schreibgeschützte Zeichenspeicherbereich.</param>
        /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
        public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value)
        {
            if(builder is null)
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
