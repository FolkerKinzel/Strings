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
        /// <summary>
        /// Untersucht, ob der <see cref="StringBuilder"/> Unicode-Zeichen enthält,
        /// die nicht zum ASCII-Zeichensatz gehören.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt untersucht wird.</param>
        /// <returns><c>true</c>, wenn <paramref name="builder"/> ein Unicode-Zeichen enthält, das nicht zum 
        /// ASCII-Zeichensatz gehört, anderenfalls <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static bool ContainsNonAscii(this StringBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            for (int i = 0; i < builder.Length; ++i)
            {
                if (!builder[i].IsAscii())
                {
                    return true;
                }
            }
            return false;
        }


    }
}
