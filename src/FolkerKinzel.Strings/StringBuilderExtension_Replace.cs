using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Ersetzt alle Vorkommen einer angegebenen Zeichenfolge in einer Teilzeichenfolge 
    /// von <paramref name="builder"/> durch eine andere angegebene Zeichenfolge.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt geändert wird.</param>
    /// <param name="oldValue">Die zu ersetzende Zeichenfolge.</param>
    /// <param name="newValue">Die Zeichenfolge, die <paramref name="oldValue"/> ersetzt, oder <c>null</c>.</param>
    /// <param name="startIndex">Die Position in dieser Instanz, an der die Teilzeichenfolge beginnt.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, bei dem alle Instanzen von <paramref name="oldValue"/>
    /// im Bereich von <paramref name="startIndex"/> bis zum Ende von <paramref name="builder"/> durch
    /// <paramref name="newValue"/> ersetzt wurden.</returns>
    /// 
    /// <remarks>
    /// Diese Methode führt einen Ordnungsvergleich zwischen Groß- und Kleinschreibung durch, um Vorkommen von 
    /// <paramref name="oldValue"/> in der angegebenen Teilzeichenfolge zu identifizieren. Wenn <paramref name="newValue"/>
    /// &#160;<c>null</c> oder <see cref="string.Empty"/> ist, werden alle Vorkommen von <paramref name="oldValue"/> entfernt.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="oldValue"/> ist <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">Die Länge von <paramref name="oldValue"/> ist <see cref="string.Empty"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para><paramref name="startIndex"/> ist kleiner als <c>0</c></para>
    /// <para>- oder -</para>
    /// <para><paramref name="startIndex"/> gibt eine Zeichenposition außerhalb dieser Instanz an</para>
    /// <para>- oder -</para>
    /// <para>durch Verlängerung des Inhalts von <paramref name="builder"/> würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder, string oldValue, string? newValue, int startIndex)
        => builder?.Replace(oldValue, newValue, startIndex, builder.Length - startIndex) ?? throw new ArgumentNullException(nameof(builder));

    /// <summary>
    /// Ersetzt alle Vorkommen eines angegebenen Zeichens in einer Teilzeichenfolge 
    /// von <paramref name="builder"/> durch ein anderes angegebenes Zeichen.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt geändert wird.</param>
    /// <param name="oldChar">Das zu ersetzende Zeichen.</param>
    /// <param name="newChar">Das Zeichen, das <paramref name="oldChar"/> ersetzt.</param>
    /// <param name="startIndex">Die Position in dieser Instanz, an der die Teilzeichenfolge beginnt.</param>
    /// 
    /// <returns>Ein Verweis auf <paramref name="builder"/>, bei dem <paramref name="oldChar"/>
    /// im Bereich von <paramref name="startIndex"/> bis zum Ende von <paramref name="builder"/> durch
    /// <paramref name="newChar"/> ersetzt wurde.</returns>
    /// 
    /// <remarks>
    /// Diese Methode führt einen Ordnungsvergleich zwischen Groß- und Kleinschreibung durch, um Vorkommen von 
    /// <paramref name="oldChar"/> in der angegebenen Teilzeichenfolge zu identifizieren. Die Länge von <paramref name="builder"/>
    /// bleibt durch das Ersetzen unverändert.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="oldChar"/> ist <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">Die Länge von <paramref name="oldChar"/> ist <see cref="string.Empty"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para><paramref name="startIndex"/> ist kleiner als <c>0</c></para>
    /// <para>- oder -</para>
    /// <para><paramref name="startIndex"/> gibt eine Zeichenposition außerhalb dieser Instanz an</para>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder, char oldChar, char newChar, int startIndex)
        => builder?.Replace(oldChar, newChar, startIndex, builder.Length - startIndex) ?? throw new ArgumentNullException(nameof(builder));
}
