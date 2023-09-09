namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>
    /// Gibt an, ob in einem <see cref="string"/> eines der beiden Zeichen vorkommt,
    /// die der Methode als Argumente übergeben werden.
    /// </summary>
    /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
    /// <param name="value0">Das erste zu suchende Zeichen.</param>
    /// <param name="value1">Das zweite zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in <paramref name="s"/> gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Für den Vergleich wird <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T)</see> verwendet.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char value0, char value1)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.AsSpan().ContainsAny(value0, value1);

    /// <summary>
    /// Gibt an, ob in einem <see cref="string"/> eines der drei Zeichen vorkommt,
    /// die der Methode als Argumente übergeben werden.
    /// </summary>
    /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
    /// <param name="value0">Das erste zu suchende Zeichen.</param>
    /// <param name="value1">Das zweite zu suchende Zeichen.</param>
    /// <param name="value2">Das dritte zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in <paramref name="s"/>
    /// gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Für den Vergleich wird 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, T, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T, T)</see> 
    /// verwendet.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char value0, char value1, char value2)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.AsSpan().ContainsAny(value0, value1, value2);

    /// <summary>
    /// Gibt an, ob in einem <see cref="string"/> eines der Zeichen vorkommt,
    /// die der Methode in einer schreibgeschützten Zeichenspanne übergeben werden.
    /// </summary>
    /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
    /// <param name="anyOf">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in <paramref name="s"/> gefunden wird,
    /// andernfalls <c>false</c>. Wenn <paramref name="s"/> oder <paramref name="anyOf"/> die Länge 0 haben,
    /// wird <c>false</c> zurückgegeben.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="anyOf"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>. 
    /// Ist die Länge von <paramref name="anyOf"/>
    /// größer, wird <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see> verwendet.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    public static bool ContainsAny(this string s, ReadOnlySpan<char> anyOf)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : !anyOf.IsEmpty && s.IndexOfAny(anyOf, 0, s.Length) != -1;

    /// <summary>
    /// Gibt an, ob in einem <see cref="string"/> eines der Zeichen vorkommt,
    /// die der Methode als Zeichenarray übergeben werden.
    /// </summary>
    /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
    /// <param name="anyOf">Ein Array, das die zu suchenden Zeichen enthält.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in <paramref name="s"/> gefunden wird, 
    /// andernfalls <c>false</c>. Wenn <paramref name="s"/> oder <paramref name="anyOf"/> die Länge 0 haben,
    /// wird <c>false</c> zurückgegeben.</returns>
    /// <remarks>Für den Vergleich wird <see cref="string.IndexOfAny(char[])"/> verwendet.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> oder <paramref name="anyOf"/> ist <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char[] anyOf)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.IndexOfAny(anyOf) != -1 && anyOf.Length != 0;

}
