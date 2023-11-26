using System.Diagnostics;
using System.Runtime.InteropServices;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

/// <summary>Static class that provides methods to encode and decode strings in Base64
/// format.</summary>
#if !(NET45 || NETSTANDARD2_0)
[SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
#endif
public static class Base64
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;

    private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    private const int CHAR_WIDTH = 6;
    private const string URL_ENCODED_PADDING = "%3d";

    /// <summary>Calculates the exact output length of Base64-encoded data from the input
    /// length of the data to be encoded.</summary>
    /// <param name="inputLength">The number of <see cref="byte" />s to convert to Base64
    /// format.</param>
    /// <returns>The number of characters of the Base64-encoded output when 
    /// <paramref name="inputLength" />&#160;<see cref="byte" />s are encoded.</returns>
    /// <remarks>Any line breaks that might have to be inserted into the encoded output are
    /// not included in the calculation.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetEncodedLength(int inputLength) 
        => (int)Math.Ceiling(inputLength / 3.0) << 2;

    /// <summary>Converts a <see cref="byte" /> collection to a corresponding Base64-encoded
    /// string. You can determine, whether line breaks are to be inserted into the return
    /// value.</summary>
    /// <param name="bytes">A <see cref="byte" /> collection that contains the data to encode,
    /// or <c>null</c>.</param>
    /// <param name="options">One of the enumeration values, which specify whether or not
    /// line breaks are to be inserted into the return value. The default is <see cref="Base64FormattingOptions.None"
    /// />.</param>
    /// <returns>The string representation of the elements in <paramref name="bytes" /> as
    /// Base64.</returns>
    /// <exception cref="ArgumentException"> <paramref name="options" /> is not a defined
    /// <see cref="Base64FormattingOptions" /> value.</exception>
    public static string Encode(IEnumerable<byte>? bytes,
                                Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        bytes ??= _Array.Empty<byte>();

        return bytes switch
        {
            byte[] arr => Convert.ToBase64String(arr, options),
#if NET5_0_OR_GREATER
            List<byte> list => Convert.ToBase64String(CollectionsMarshal.AsSpan(list), options),
#endif
            _ => Convert.ToBase64String(bytes.ToArray(), options),
        };
    }

    /// <summary>Converts a <see cref="byte" /> array to a corresponding Base64-encoded string.
    /// You can determine, whether line breaks are to be inserted into the return value.</summary>
    /// <param name="bytes">A <see cref="byte" /> array that contains the data to encode,
    /// or <c>null</c>.</param>
    /// <param name="options">One of the enumeration values, which specify whether or not
    /// line breaks are to be inserted into the return value. The default is 
    /// <see cref="Base64FormattingOptions.None" />.</param>
    /// <returns>The string representation of the elements in <paramref name="bytes" /> as
    /// Base64.</returns>
    /// <exception cref="ArgumentException"> <paramref name="options" /> is not a defined
    /// <see cref="Base64FormattingOptions" /> value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[]? bytes,
                                Base64FormattingOptions options = Base64FormattingOptions.None)
        => Convert.ToBase64String(bytes ?? [], options);

    /// <summary>Converts a subset of a <see cref="byte" /> array to its equivalent Base64-encoded
    /// string representation. Parameters specify the subset as an offset in the input array,
    /// the number of bytes to be converted, and whether newlines are to be inserted in the
    /// return value.</summary>
    /// <param name="bytes">A <see cref="byte" /> array that contains the data to encode.</param>
    /// <param name="offset">An offset in <paramref name="bytes" />.</param>
    /// <param name="length">The number of Bytes that are to be converted.</param>
    /// <param name="options">One of the enumeration values, which specify whether or not
    /// line breaks are to be inserted into the return value. The default is 
    /// <see cref="Base64FormattingOptions.None" />.</param>
    /// <returns>The Base64 string representation of <paramref name="length" /> Bytes taken
    /// from the Array <paramref name="bytes" /> beginning at the index <paramref name="offset"
    /// />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="bytes" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="offset" /> or <paramref name="length" /> are negative values.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="offset" /> plus <paramref name="length" /> is greater than the length
    /// of <paramref name="bytes" />.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="options" /> is not a defined
    /// <see cref="Base64FormattingOptions" /> value.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[] bytes,
                                int offset,
                                int length,
                                Base64FormattingOptions options = Base64FormattingOptions.None)
        => bytes is null ? throw new ArgumentNullException(nameof(bytes))
                         : Convert.ToBase64String(bytes, offset, length, options);


    /// <summary>Converts a read-only <see cref="byte" /> span to a corresponding Base64-encoded
    /// string. Optional you can determine, whether line breaks are to be inserted into the
    /// return value.</summary>
    /// <param name="bytes">A read-only <see cref="byte" /> span that contains the data to
    /// encode.</param>
    /// <param name="options">One of the enumeration values, which specify whether or not
    /// line breaks are to be inserted into the return value. The default is 
    /// <see cref="Base64FormattingOptions.None" />.</param>
    /// <returns>The Base64 string reprensentation of the elements in <paramref name="bytes"
    /// />.</returns>
    /// <remarks>
    /// <note type="note">
    /// In the .NET-Framework 4.5 and .NET Standard 2.0 versions of the nuget package, the method 
    /// has to allocate a new Array. For this reason it is recommended, to use the overloads 
    /// <see cref="Encode(byte[], int, int, Base64FormattingOptions)" /> or 
    /// <see cref="Encode(byte[], Base64FormattingOptions)" /> when supporting old framework versions. 
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentException"> <paramref name="options" /> is not a defined
    /// <see cref="Base64FormattingOptions" /> value.</exception>
    /// <exception cref="OutOfMemoryException">The output length was greater than 
    /// <see cref="int.MaxValue">Int32.MaxValue</see>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(ReadOnlySpan<byte> bytes,
                                Base64FormattingOptions options = Base64FormattingOptions.None)
#if NET45 || NETSTANDARD2_0
       => Convert.ToBase64String(bytes.ToArray(), options);
#else
       => Convert.ToBase64String(bytes, options);
#endif


    /// <summary>Converts the Base64-encoded <see cref="string"/> into a <see cref="byte"/> 
    /// array.</summary>
    /// <param name="base64">The string to convert, or <c>null</c>.</param>
    /// <returns>A byte array decoded from <paramref name="base64" />.</returns>
    /// <exception cref="FormatException">
    /// <para>
    /// The length of <paramref name="base64" /> with ignored white space characters is not
    /// zero or a multiple of 4.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// The format of <paramref name="base64" /> is invalid. <paramref name="base64" /> contains
    /// a non-Base64 character, more than two padding characters, or a non-space character
    /// between the padding characters.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string? base64) => Convert.FromBase64String(base64 ?? "");


    /// <summary>Converts a Base64-string into a corresponding <see cref="byte"/> array and 
    /// allows to pass options for the conversion.</summary>
    /// <param name="base64">The <see cref="string"/> to convert, or <c>null</c>.</param>
    /// <param name="options">Options for the conversion.</param>
    /// <returns>A <see cref="byte"/> array decoded from <paramref name="base64" />.</returns>
    /// <exception cref="FormatException">Depending on the conversion options specified with
    /// <paramref name="options" />, <paramref name="base64" /> cannot be converted into
    /// a <see cref="byte" /> array .</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string? base64,
                                  Base64ParserOptions options) 
        => GetBytes(base64.AsSpan(), options);

    /// <summary>Converts a Base64-encoded read-only character span into a corresponding
    /// <see cref="byte"/> array and allows to pass options for the conversion.</summary>
    /// <param name="base64">The read-only character span to convert.</param>
    /// <param name="options">Options for the conversion.</param>
    /// <returns>A <see cref="byte"/> array decoded from <paramref name="base64" />.</returns>
    /// <exception cref="FormatException">Depending on the conversion options specified with
    /// <paramref name="options" />, <paramref name="base64" /> cannot be converted into
    /// a <see cref="byte" /> array .</exception>
    public static byte[] GetBytes(ReadOnlySpan<char> base64, Base64ParserOptions options)
    {
        base64 = base64.Trim();

        if (base64.IsEmpty)
        {
            return GetEmptyByteArray();
        }

        char[]? arr = null;
        Span<char> contentSpan = default;

        if (options.HasFlag(Base64ParserOptions.AcceptBase64Url) && IsBase64Url(base64))
        {
            arr = new char[base64.Length + 2];
            contentSpan = arr.AsSpan(0, base64.Length);
            base64.CopyTo(contentSpan);

            int urlEncodedPaddingCount = ReplaceUrlEncodedPadding(arr, ref contentSpan);
            ReplaceBase64UrlChars(contentSpan, urlEncodedPaddingCount);
            base64 = contentSpan;
        }

        int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding) 
                                            ? GetMissingPaddingCount(base64) 
                                            : 0;

        if (missingPaddingCount != 0)
        {
            if (arr is null)
            {
                arr = new char[base64.Length + missingPaddingCount];
                contentSpan = arr.AsSpan();
                base64.CopyTo(contentSpan);
            }
            else
            {
                Debug.Assert(arr.Length >= contentSpan.Length + missingPaddingCount);
                contentSpan = arr.AsSpan(0, contentSpan.Length + missingPaddingCount);
            }

            ApplyPadding(contentSpan, missingPaddingCount);
            base64 = contentSpan;
        }

        return DoGetBytes(base64);

        /////////////////////////////////////////////////////

        static int GetMissingPaddingCount(ReadOnlySpan<char> base64)
        {
            int whiteSpaceLength = 0;

            for (int i = 0; i < base64.Length; i++)
            {
                if (base64[i] < '!')
                {
                    whiteSpaceLength++;
                }
            }

            return ((base64.Length - whiteSpaceLength) % 4) 
                   switch { 0 => 0, 2 => 2, 3 => 1, _ => throw new FormatException() };
        }

        static bool IsBase64Url(ReadOnlySpan<char> base64)
            => base64.EndsWith(URL_ENCODED_PADDING,
                               StringComparison.OrdinalIgnoreCase) || base64.ContainsAny("-_");


        static int ReplaceUrlEncodedPadding(char[]? arr, ref Span<char> span)
        {
            int urlEncodedPaddingCount = 0;

            // This is based on the assumption that Base64Url contains no white space -
            // neither URL-encoded nor unencoded.
            while (span.EndsWith(URL_ENCODED_PADDING, StringComparison.OrdinalIgnoreCase))
            {
                span = span.Slice(0, span.Length - 3);
                urlEncodedPaddingCount++;
            }

            if (urlEncodedPaddingCount != 0)
            {
                span = arr.AsSpan(0, span.Length + urlEncodedPaddingCount);
                ApplyPadding(span, urlEncodedPaddingCount);
            }

            return urlEncodedPaddingCount;
        }

        static void ReplaceBase64UrlChars(Span<char> span, int urlEncodedPaddingCount)
        {
            int replacementLength = span.Length - urlEncodedPaddingCount;
            for (int i = 0; i < replacementLength; i++)
            {
                char c = span[i];

                if (c == '-')
                {
                    span[i] = '+';
                }
                else if (c == '_')
                {
                    span[i] = '/';
                }
            }
        }

        static void ApplyPadding(Span<char> span, int urlEncodedPaddingCount)
        {
            for (int i = 1; i <= urlEncodedPaddingCount; i++)
            {
                span[span.Length - i] = '=';
            }
        }
    }

    /// <summary>Converts a Base64-encoded read-only character span into a corresponding
    /// <see cref="byte"/> array.</summary>
    /// <param name="base64">The read-only character span to convert.</param>
    /// <returns>A byte array decoded from <paramref name="base64" />.</returns>
    /// <exception cref="FormatException">
    /// <para>
    /// The length of <paramref name="base64" /> with ignored white space characters is not
    /// zero or a multiple of 4.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// The format of <paramref name="base64" /> is invalid. <paramref name="base64" /> contains
    /// a non-Base64 character, more than two padding characters, or a non-space character
    /// between the padding characters.
    /// </para>
    /// </exception>
    public static byte[] GetBytes(ReadOnlySpan<char> base64)
    {
        base64 = base64.Trim();
        return base64.IsEmpty ? GetEmptyByteArray() : DoGetBytes(base64);
    }

    private static byte[] DoGetBytes(ReadOnlySpan<char> base64)
    {
        Debug.Assert(!base64.IsWhiteSpace());

#if NET45 || NETSTANDARD2_0
        return Convert.FromBase64String(base64.ToString());
#else
        int outputSize = ComputeMaxOutputSize(base64);

        byte[] output = new byte[outputSize];

        return Convert.TryFromBase64Chars(base64, output, out outputSize)
            ? output.Length == outputSize ? output : output[0..outputSize]
            : throw new FormatException();
#endif
    }


#if !(NET45 || NETSTANDARD2_0)
    private static int ComputeMaxOutputSize(ReadOnlySpan<char> base64)
    {
        int outLength = (base64.Length >> 2) * 3;

        try
        {
            if (base64[base64.Length - 1] == '=')
            {
                --outLength;
            }

            if (base64[base64.Length - 2] == '=')
            {
                --outLength;
            }
        }
        catch
        {
            throw new FormatException();
        }

        return outLength;
    }
#endif

    internal static StringBuilder AppendEncodedTo(StringBuilder builder,
                                                  ReadOnlySpan<byte> bytes,
                                                  Base64FormattingOptions options)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        // Don't put in any effort to compute the needed capacity of the line breaks
        // because StringBuilder will allocate NEW memory each time you call Insert()
        builder.EnsureCapacity(builder.Length + GetEncodedLength(bytes.Length));
        int startOfBase64 = builder.Length;

        Base64.AppendEncodedTo(builder, bytes);

        if (options.HasFlag(Base64FormattingOptions.InsertLineBreaks) && !bytes.IsEmpty)
        {
            InsertLineBreaks(builder, startOfBase64);
        }

        return builder;
    }

    private static void InsertLineBreaks(StringBuilder builder, int startOfBase64)
    {
        int currentLineStartIndex = builder.LastIndexOf('\n', startOfBase64) + 1;

        if (startOfBase64 - currentLineStartIndex < Base64.LINE_LENGTH)
        {
            startOfBase64 = currentLineStartIndex;
        }
        else
        {
            builder.Insert(startOfBase64, Base64.LINE_BREAK);
            startOfBase64 += Base64.LINE_BREAK.Length;
        }

        int nextLineStart = startOfBase64 + Base64.LINE_LENGTH;

        while (nextLineStart < builder.Length)
        {
            builder.Insert(nextLineStart, Base64.LINE_BREAK);
            nextLineStart += Base64.LINE_BREAK.Length + Base64.LINE_LENGTH;
        }
    }

    private static void AppendEncodedTo(StringBuilder sb, ReadOnlySpan<byte> data)
    {
        Debug.Assert(sb != null);

        // paddingLength may be 3, but finalPartLength is 0 then and no 
        // padding will be added:
        int paddingLength = CHUNK_LENGTH - data.Length % CHUNK_LENGTH;
        int finalPartLength = CHUNK_LENGTH - paddingLength;

        AppendChunks2(sb, data, finalPartLength);

        if (finalPartLength > 0)
        {
            AppendFinalBlock(sb, data, paddingLength, finalPartLength);
        }
    }

    private static void AppendChunks2(StringBuilder sb, ReadOnlySpan<byte> data, int finalPartLength)
    {
        if (data.Length < CHUNK_LENGTH)
        {
            return;
        }

        int counter = 0;
        ReadOnlySpan<char> idx = IDX.AsSpan();

        while (counter < data.Length - finalPartLength)
        {
            int i = data[counter] << 16;
            i |= data[counter + 1] << 8;
            i |= data[counter + 2];

            _ = sb.Append(idx[i >> 3 * CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i >> 2 * CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i >> CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i & CHAR_MASK]);

            counter += CHUNK_LENGTH;
        }
    }

    private static void AppendFinalBlock(StringBuilder sb, ReadOnlySpan<byte> data, int paddingLength, int finalPartLength)
    {
        int dataHolder = 0;

        for (int j = 0; j < finalPartLength; j++)
        {
            dataHolder <<= 8;
            dataHolder |= data[data.Length - (finalPartLength - j)];
        }

        dataHolder <<= paddingLength * 2;

        int remainingDataLength = 4 - paddingLength;

        for (int j = 1; j <= remainingDataLength; j++)
        {
            int shift = (remainingDataLength - j) * CHAR_WIDTH;
            sb.Append(IDX[dataHolder >> shift & CHAR_MASK]);
        }

        for (int j = 0; j < paddingLength; j++)
        {
            sb.Append('=');
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte[] GetEmptyByteArray() =>
#if NET45
            new byte[0];
#else
            Array.Empty<byte>();
#endif

}
