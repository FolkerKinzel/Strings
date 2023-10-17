using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="StringBuilder" /> class.</summary>
/// <threadsafety static="true" instance="false" />
public static partial class StringBuilderExtension
{
    /// <summary>Generates the same <see cref="int" /> hash code for an identical string
    /// of characters each time the program is run.</summary>
    /// <param name="builder">The Char sequence to be hashed.</param>
    /// <param name="hashType">The kind of hashcode to be generated.</param>
    /// <returns>The hashcode.</returns>
    /// <remarks>
    /// <para>
    /// The method <see cref="string.GetHashCode">String.GetHashCode()</see> returns a different
    /// hash code for an identical string with each program run for security reasons. Apart
    /// from the fact that the hash algorithm of <see cref="string.GetHashCode">String.GetHashCode()</see>
    /// could be different in different framework versions, it makes no sense to use the
    /// return value of <see cref="string.GetHashCode" /> for reuse. The alternatives, e.g.
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="hashType" /> is not a defined 
    /// value of the <see cref="HashType" /> enum.</exception>
    /// <example>
    /// <code language="cs" source="..\Examples\Example.cs" />
    /// </example>
    public static int GetPersistentHashCode(this StringBuilder builder, HashType hashType)
    {
        return builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : (hashType switch
            {
                HashType.Ordinal => GetHashCodeOrdinal(builder),
                HashType.OrdinalIgnoreCase => GetHashCodeOrdinalIgnoreCase(builder),
                HashType.AlphaNumericIgnoreCase => GetHashCodeAlphaNumericIgnoreCase(builder),
                _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType))
            });
    }

    #region private Methods

    #region GetHashCode

    private static int GetHashCodeOrdinal(StringBuilder sb)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < sb.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ sb[i];
                if (i == sb.Length - 1)
                {
                    break;
                }
                hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ sb[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }


    private static int GetHashCodeOrdinalIgnoreCase(StringBuilder sb)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < sb.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(sb[i]);
                if (i == sb.Length - 1)
                {
                    break;
                }
                hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ char.ToUpperInvariant(sb[i + 1]);
            }

            return hash1 + (hash2 * 1566083941);
        }
    }


    private static int GetHashCodeAlphaNumericIgnoreCase(StringBuilder sb)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < sb.Length;)
            {
                for (; i < sb.Length; i++)
                {
                    char current = sb[i];

                    if (char.IsLetterOrDigit(current))
                    {
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ char.ToUpperInvariant(current);
                        i++;

                        // Hashe nächstes Zeichen:
                        for (; i < sb.Length; i++)
                        {
                            char next = sb[i];

                            if (char.IsLetterOrDigit(next))
                            {
                                hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ char.ToUpperInvariant(next);
                                i++;
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            return hash1 + (hash2 * 1566083941);
        }
    }

    #endregion

    #endregion

}
