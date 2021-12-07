namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Gibt den NULL-basierten Index des ersten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
    /// <returns>Die nullbasierte Indexposition von <paramref name="value"/> ab dem Anfang des <see cref="StringBuilder"/>s,
    /// wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    public static int IndexOf(this StringBuilder builder, char value)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.IndexOf(value, 0, builder.Length);

    /// <summary>
    /// Gibt den NULL-basierten Index des ersten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an. 
    /// Die Suche beginnt an der angegebenen Zeichenposition.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche.</param>
    /// <returns>Die nullbasierte Indexposition von <paramref name="value"/> ab dem Anfang des <see cref="StringBuilder"/>s,
    /// wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> ist kleiner als 0 oder
    /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.</exception>
    public static int IndexOf(this StringBuilder builder, char value, int startIndex)
        => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : builder.IndexOf(value, startIndex, builder.Length - startIndex);


    /// <summary>
    /// Gibt den NULL-basierten Index des ersten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an. 
    /// Die Suche beginnt an einer angegebenen Zeichenposition, und es wird eine angegebene Anzahl 
    /// von Zeichenpositionen überprüft.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
    /// <returns>Die nullbasierte Indexposition von <paramref name="value"/> ab dem Anfang des <see cref="StringBuilder"/>s,
    /// wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex"/> oder <paramref name="count"/> sind kleiner als 0 oder
    /// größer als die Anzahl der Zeichen in <paramref name="builder"/>
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="startIndex"/> + <paramref name="count"/> ist größer als die Anzahl der Zeichen in
    /// <paramref name="builder"/>.
    /// </para></exception>
    public static int IndexOf(this StringBuilder builder, char value, int startIndex, int count)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count += startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        for (int i = startIndex; i < count; ++i)
        {
            if (value == builder[i])
            {
                return i;
            }
        }
        return -1;
    }
}
