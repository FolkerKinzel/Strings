namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Wandelt den gesamten Inhalt eines <see cref="StringBuilder"/>s in Kleinbuchstaben um und verwendet
    /// dabei die Regeln der invarianten Kultur.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    public static StringBuilder ToLowerInvariant(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ToLowerInvariant(0, builder.Length);

    /// <summary>
    /// Wandelt den Inhalt eines <see cref="StringBuilder"/>s beginnend bei <paramref name="startIndex"/>
    /// in Kleinbuchstaben um und verwendet
    /// dabei die Regeln der invarianten Kultur.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Umwandlung
    /// beginnt.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> ist kleiner als 0 oder
    /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.</exception>
    public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ToLowerInvariant(startIndex, builder.Length - startIndex);

    /// <summary>
    /// Wandelt den Inhalt eines Abschnitts in <see cref="StringBuilder"/>, der bei <paramref name="startIndex"/>
    /// beginnt und <paramref name="count"/> Zeichen umfasst, in Kleinbuchstaben um und verwendet
    /// dabei die Regeln der invarianten Kultur.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Umwandlung
    /// beginnt.</param>
    /// <param name="count">Die Anzahl der zu bearbeitenden Zeichen.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
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
    public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex, int count)
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

        for (int i = startIndex; i < count; i++)
        {
            builder[i] = char.ToLowerInvariant(builder[i]);
        }

        return builder;
    }



}
