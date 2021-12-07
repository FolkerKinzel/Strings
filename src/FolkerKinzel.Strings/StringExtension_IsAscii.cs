namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>
    /// Untersucht, ob der <see cref="string"/> Unicode-Zeichen enthält,
    /// die nicht zum ASCII-Zeichensatz gehören.
    /// </summary>
    /// <param name="s">Der zu durchsuchende <see cref="string"/>.</param>
    /// <returns><c>false</c>, wenn <paramref name="s"/> ein Unicode-Zeichen enthält, das nicht zum 
    /// ASCII-Zeichensatz gehört, andernfalls <c>true</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    public static bool IsAscii(this string s)
        => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().IsAscii();

}
