using System;
using System.Runtime.CompilerServices;
using System.Text;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Properties;

namespace Benchmarks;

internal struct PersistentStringHash(HashType hashType)
{
    private readonly HashType _hashType = hashType switch
    {
        HashType.Ordinal or HashType.OrdinalIgnoreCase or HashType.AlphaNumericIgnoreCase => hashType,
        _ => throw new ArgumentException(Res.UndefinedEnumValue, nameof(hashType)),
    };

    private const int INITIAL_VALUE = (5381 << 16) + 5381;

    private int _hash1 = INITIAL_VALUE;

    private int _hash2 = INITIAL_VALUE;

    public readonly HashType HashType => _hashType;

    public readonly int Hash
    {
        get
        {
            unchecked { return _hash1 + (_hash2 * 1566083941); }
        }
    }

    public override readonly int GetHashCode() => Hash;

    public void Append(ReadOnlySpan<char> chars)
    {
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
                throw new InvalidOperationException("Don't instantiate this struct with the default constructor!");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(StringBuilder builder)
        => DoAppend(builder, 0, builder?.Length ?? throw new ArgumentNullException(nameof(builder)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(StringBuilder builder, int startIndex)
        => DoAppend(builder, startIndex, builder?.Length - startIndex ?? throw new ArgumentNullException(nameof(builder)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        DoAppend(builder, startIndex, count);
    }

    private void DoAppend(StringBuilder builder, int startIndex, int count)
    { 
        if(startIndex < 0 || (startIndex + count) > builder.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        if(count == 0) { return; }

        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if(startIndex < pos + chunk.Length)
            {
                int spanStart = startIndex - pos;
                ReadOnlySpan<char> span = chunk.Span.Slice(spanStart, Math.Min(chunk.Length - spanStart, count));
                count -= span.Length;
                Append(span);

                if(count == 0)
                {
                    return; 
                }
            }
        }
    }

    private void GetHashCodeOrdinal(ReadOnlySpan<char> span)
    {
        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            for (int i = 0; i < span.Length; i += 2)
            {
                _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ span[i];

                if (i == span.Length - 1)
                {
                    break;
                }

                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ span[i + 1];
            }

            //return hash1 + (hash2 * 1566083941);
        }
    }

    private void GetHashCodeOrdinalIgnoreCase(ReadOnlySpan<char> span)
    {
        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            for (int i = 0; i < span.Length; i += 2)
            {
                _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ char.ToUpperInvariant(span[i]);
                if (i == span.Length - 1)
                {
                    break;
                }
                _hash2 = ((_hash2 << 5) + _hash2 + (_hash2 >> 27)) ^ char.ToUpperInvariant(span[i + 1]);
            }

            //return hash1 + (hash2 * 1566083941);
        }
    }

    private void GetHashCodeAlphaNumericNoCase(ReadOnlySpan<char> span)
    {
        unchecked
        {
            //int hash1 = (5381 << 16) + 5381;
            //int hash2 = hash1;

            for (int i = 0; i < span.Length;)
            {
                for (; i < span.Length; i++)
                {
                    char current = span[i];

                    if (char.IsLetterOrDigit(current))
                    {
                        _hash1 = ((_hash1 << 5) + _hash1 + (_hash1 >> 27)) ^ char.ToUpperInvariant(current);
                        i++;

                        // Hashe nächstes Zeichen:
                        for (; i < span.Length; i++)
                        {
                            char next = span[i];

                            if (char.IsLetterOrDigit(next))
                            {
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
