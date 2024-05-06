using System.ComponentModel;
using System.Runtime.InteropServices;
using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>
/// Combines the hash code for multiple character based values into a single persistent hash code.
/// </summary>
/// <param name="hashType">The type of hash code.</param>
/// <remarks>
/// <para>
/// <note type="important">
/// Keep in mind that this is a value type. Don't forget the <c>ref</c> keyword when passing instances
/// to other methods!
/// </note>
/// </para>
/// <para>
/// <note type="warning">
/// Never use the default constructor!
/// </note>
/// </para>
/// </remarks>
[SuppressMessage("Usage", "CA2231:Overload operator equals on overriding value type Equals", 
    Justification = "PersistentStringHash is a mutable struct and should not be compared with other instances.")]
[StructLayout(LayoutKind.Auto)]
public struct PersistentStringHash(HashType hashType)
{
    private readonly HashType _hashType = hashType switch
    {
        HashType.Ordinal or HashType.OrdinalIgnoreCase or HashType.AlphaNumericIgnoreCase => hashType,
        _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType)),
    };

    private const int INITIAL_VALUE = (5381 << 16) + 5381;
    private int _hash1 = INITIAL_VALUE;
    private int _hash2 = INITIAL_VALUE;
    private bool _odd = false;

    /// <summary>
    /// The type of hash code this instance computes.
    /// </summary>
    public readonly HashType HashType => _hashType;

    /// <summary>
    /// Calculates the final hash code after consecutive Add invocations.
    /// </summary>
    /// <returns>The calculated hash code.</returns>
    public readonly int ToHashCode()
    {
        unchecked { return _hash1 + (_hash2 * 1566083941); }
    }

    /// <summary>
    /// This method is not supported and should not be called.
    /// </summary>
    /// <param name="obj">Ignored</param>
    /// <returns>This method will always throw a <see cref="NotSupportedException"/>.</returns>
    /// <exception cref="NotSupportedException">This method is not supported.</exception>
    [Obsolete(
        $"""
        PersistentStringHash is a mutable struct and should not be compared with other instances.
        """, true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    public override readonly bool Equals([NotNullWhen(true)] object? obj) => throw new NotSupportedException();
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member

    /// <summary>
    /// This method is not supported and should not be called.
    /// </summary>
    /// <returns>This method will always throw a <see cref="NotSupportedException"/>.</returns>
    /// <exception cref="NotSupportedException">This method is not supported.</exception>
    [Obsolete(
        $"""
        PersistentStringHash is a mutable struct and should not be compared with other instances. 
        Use ToHashCode() to retrieve the computed hash code.
        """, true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    public override readonly int GetHashCode() => throw new NotSupportedException();
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member

    /// <summary>
    /// Adds the content of a read-only character span to the hash code.
    /// </summary>
    /// <param name="chars">A span of Unicode characters.</param>
    /// <exception cref="InvalidOperationException">
    /// The instance had been initialized using the default constructor.
    /// </exception>
    public void Add(ReadOnlySpan<char> chars)
    {
        if(chars.Length == 0)
        {
            return;
        }

        switch (_hashType)
        {
            case HashType.Ordinal:
                GetHashCodeOrdinal(chars);
                break;
            case HashType.OrdinalIgnoreCase:
                GetHashCodeOrdinalIgnoreCase(chars);
                break;
            case HashType.AlphaNumericIgnoreCase:
                GetHashCodeAlphaNumericNoCase(chars);
                break;
            default:
                throw new InvalidOperationException(Res.DefaultCtor);
        }
    }

    /// <summary>
    /// Adds a single character to the hash code.
    /// </summary>
    /// <param name="c">The <see cref="char"/> to hash.</param>
    [SuppressMessage("Style", "IDE0302:Simplify collection initialization",
        Justification = "Performance: Collection expression allocates a new array.")]
    public void Add(char c)
     => Add(stackalloc char[] { c });

    /// <summary>
    /// Adds the content of a <see cref="StringBuilder"/> to the hash code.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> whose content is 
    /// hashed.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="builder"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The instance had been initialized using the default constructor.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(StringBuilder builder)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));
#if NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
        DoAdd(builder, 0, builder.Length);
#else
        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            Add(chunk.Span);
        }
#endif
    }

    /// <summary>
    /// Adds a sequence of characters from the content of a <see cref="StringBuilder"/>
    /// to the hash code that begins with <paramref name="startIndex"/> and reaches to 
    /// the end of <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> whose content is 
    /// hashed.</param>
    /// <param name="startIndex"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// <paramref name="builder"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    /// <exception cref="InvalidOperationException">
    /// The instance had been initialized using the default constructor.
    /// </exception>
    public void Add(StringBuilder builder, int startIndex)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if ((uint)startIndex > (uint)builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        DoAdd(builder, startIndex, builder.Length - startIndex);
    }

    /// <summary>
    /// Adds a sequence of characters from the content of a <see cref="StringBuilder"/>
    /// to the hash code that begins with <paramref name="startIndex"/> and contains 
    /// <paramref name="count"/> characters.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> whose content is 
    /// hashed.</param>
    /// <param name="startIndex">The start index in builder.</param>
    /// <param name="count">The number of characters to hash.</param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// <paramref name="builder"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// or larger than the number of characters in <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="builder" />.
    /// </para>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The instance had been initialized using the default constructor.
    /// </exception>
    public void Add(StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if ((uint)startIndex > (uint)builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if ((uint)count > (uint)(builder.Length - startIndex))
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        DoAdd(builder, startIndex, count);
    }

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

    private void DoAdd(StringBuilder builder, int startIndex, int count)
    {
        if (count == 0)
        {
            return; 
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        builder.CopyTo(startIndex, shared.Array, 0, count);
        Add(shared.Array.AsSpan(0, count));
    }
#else

    private void DoAdd(StringBuilder builder, int startIndex, int count)
    {
        if (count == 0)
        {
            return;
        }

        int chunkStart = 0;

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (startIndex >= chunkStart + chunk.Length)
            {
                chunkStart += chunk.Length;
                continue;
            }

            int spanStart = startIndex - chunkStart;
            ReadOnlySpan<char> span = chunk.Span.Slice(spanStart, Math.Min(chunk.Length - spanStart, count));
            Add(span);

            if (count == span.Length)
            {
                return;
            }

            count -= span.Length;
            chunkStart += chunk.Length;
            startIndex = chunkStart;
        }
    }

#endif

    private void GetHashCodeOrdinal(ReadOnlySpan<char> span)
    {
        Debug.Assert(span.Length > 0);

        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            if(_odd)
            {
                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ span[0];
                _odd = false;
                span = span.Slice(1);
            }

            for (int i = 0; i < span.Length; i += 2)
            {
                _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ span[i];

                if (i == span.Length - 1)
                {
                    _odd = true;
                    break;
                }

                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ span[i + 1];
            }

            //return hash1 + (hash2 * 1566083941);
        }
    }

    private void GetHashCodeOrdinalIgnoreCase(ReadOnlySpan<char> span)
    {
        Debug.Assert(span.Length > 0);

        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            if (_odd)
            {
                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ char.ToUpperInvariant(span[0]);
                _odd = false;
                span = span.Slice(1);
            }

            for (int i = 0; i < span.Length; i += 2)
            {
                _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ char.ToUpperInvariant(span[i]);

                if (i == span.Length - 1)
                {
                    _odd = true;
                    break;
                }

                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ char.ToUpperInvariant(span[i + 1]);
            }

            //return hash1 + (hash2 * 1566083941);
        }
    }

    private void GetHashCodeAlphaNumericNoCase(ReadOnlySpan<char> span)
    {
        Debug.Assert(span.Length > 0);

        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            if (_odd) 
            {
                for (int i = 0; i < span.Length; i++)
                {
                    char c = span[i];

                    if (char.IsLetterOrDigit(c))
                    {
                        _odd = false;
                        _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ char.ToUpperInvariant(c);
                        span = span.Slice(++i);
                        break;
                    }
                }
            }

            for (int i = 0; i < span.Length;)
            {
                for (; i < span.Length; i++)
                {
                    char current = span[i];

                    if (char.IsLetterOrDigit(current))
                    {
                        _odd = true;
                        _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ char.ToUpperInvariant(current);
                        i++;

                        // Hash next character:
                        for (; i < span.Length; i++)
                        {
                            char next = span[i];

                            if (char.IsLetterOrDigit(next))
                            {
                                _odd = false;
                                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ char.ToUpperInvariant(next);
                                i++;
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            //return hash1 + (hash2 * 1566083941);
        }
    }
}
