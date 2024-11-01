using System.Security.Cryptography;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="Span{T}">Span&lt;Char&gt;</see> struct</summary>
/// <threadsafety static="true" instance="false" />
public static partial class SpanExtension
{
    /// <summary>Generates the same <see cref="int" /> hash code for an identical string
    /// of characters each time the program is run.</summary>
    /// <param name="span">The Char sequence to be hashed.</param>
    /// <param name="hashType">The kind of hashcode to be generated.</param>
    /// <returns>The hashcode.</returns>
    /// <remarks>
    /// <para>
    /// The method <see cref="string.GetHashCode()">String.GetHashCode()</see> returns a different
    /// hash code for an identical string with each program run for security reasons. Apart
    /// from the fact that the hash algorithm of <see cref="string.GetHashCode()">String.GetHashCode()</see>
    /// could be different in different framework versions, it makes no sense to use the
    /// return value of <see cref="string.GetHashCode()" /> for reuse. The alternatives, e.g.
    /// <see cref="MD5" /> or <see cref="SHA256" />, use more storage space and are slower.
    /// This method offers a slim alternative that is suitable for hashing very short strings
    /// that are not used in a security-critical context.
    /// </para>
    /// <para>
    /// The hashcode generated by this method is not identical to the hashcode generated
    /// by the .NET Framework 4.0, because it uses roundshifting to preserve more information.
    /// </para>
    /// <para>
    /// The hashcodes generated with different values for <paramref name="hashType" /> may
    /// provide different hashcodes for an identical Char sequence and MUST therefore not
    /// be mixed.
    /// </para>
    /// <para>
    /// Do not use the hashcodes generated by this method for security-critical purposes
    /// (such as hashing passwords)!
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException"> <paramref name="hashType" /> is not a defined 
    /// value of the <see cref="HashType" /> enum.</exception>
    /// <example>
    /// <code language="cs" source="..\Examples\Example.cs" />
    /// </example>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetPersistentHashCode(this Span<char> span, HashType hashType)
        => ReadOnlySpanExtension.GetPersistentHashCode(span, hashType);
}
