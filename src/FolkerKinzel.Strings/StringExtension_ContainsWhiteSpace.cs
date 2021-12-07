﻿namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>
    /// Gibt an, ob der <see cref="string"/> ein Leerraumzeichen enthält.
    /// </summary>
    /// <param name="s">Der zu durchsuchende <see cref="string"/>.</param>
    /// <returns><c>true</c>, wenn <paramref name="s"/> ein Leerraumzeichen enthält, andernfalls <c>false</c>.</returns>
    /// <remarks>Für den Vergleich wird <see cref="char.IsWhiteSpace(char)"/> verwendet.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    public static bool ContainsWhiteSpace(this string s)
        => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().ContainsWhiteSpace();
}
