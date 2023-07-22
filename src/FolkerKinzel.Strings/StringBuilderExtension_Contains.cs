namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Gibt an, ob ein angegebenes Zeichen im <see cref="StringBuilder"/> vorkommt.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> in <paramref name="builder"/>
    /// gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    public static bool Contains(this StringBuilder builder, char value)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.IndexOf(value) != -1;


    /// <summary>
    /// Gibt an, ob ein angegebenes Zeichen im <see cref="StringBuilder"/> vorkommt. 
    /// Die Suche beginnt an der angegebenen Zeichenposition.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> im angegebenen Abschnitt von 
    /// <paramref name="builder"/> gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> ist kleiner als 0 oder
    /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.</exception>
    public static bool Contains(this StringBuilder builder, char value, int startIndex)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.IndexOf(value, startIndex) != -1;


    /// <summary>
    /// Gibt an, ob ein angegebenes Zeichen im <see cref="StringBuilder"/> vorkommt. 
    /// Die Suche beginnt an einer angegebenen Zeichenposition, und es wird eine angegebene Anzahl 
    /// von Zeichenpositionen überprüft.
    /// </summary>
    /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
    /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> im angegebenen Abschnitt von 
    /// <paramref name="builder"/> gefunden wird, andernfalls <c>false</c>.</returns>
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
    public static bool Contains(this StringBuilder builder, char value, int startIndex, int count)
       => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.IndexOf(value, startIndex, count) != -1;

}
