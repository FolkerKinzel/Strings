using System.Runtime.InteropServices;
using FolkerKinzel.Strings.Intls;
using Base64Bcl = System.Buffers.Text.Base64;

namespace FolkerKinzel.Strings;

/// <summary>Static class that provides methods to encode and decode strings in Base64
/// format.</summary>
#if !(NET462 || NETSTANDARD2_0  || NETSTANDARD2_1 || NETCOREAPP3_1)
[SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters",
    Justification = "Base64 characters are not localizable.")]
#endif
public static class Base64
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;
    private const int MAXIMUM_ENCODE_LENGTH = (int.MaxValue / 4) * 3;
    private const string URL_ENCODED_PADDING = "%3d";

    /// <summary>Calculates the exact output length of Base64-encoded data from the input
    /// length of the data to be encoded.</summary>
    /// <param name="length">The number of <see cref="byte" />s to convert to Base64
    /// format.</param>
    /// <returns>The number of characters of the Base64-encoded output when 
    /// <paramref name="length" />&#160;<see cref="byte" />s are encoded.</returns>
    /// <remarks>Any line breaks that might have to be inserted into the encoded output are
    /// not included in the calculation.</remarks>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c> 
    /// or as large that the return value would be greater than 
    /// <see cref="int.MaxValue">Int32.MaxValue</see>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetEncodedLength(int length)
        => (uint)length > MAXIMUM_ENCODE_LENGTH
            ? throw new ArgumentOutOfRangeException(nameof(length))
            : ((length + 2) / 3) << 2;

    /// <summary>Converts a <see cref="byte" /> collection to a corresponding Base64-encoded
    /// string. You can determine, whether line breaks are to be inserted into the return
    /// value.</summary>
    /// <param name="bytes">A <see cref="byte" /> collection that contains the data to encode,
    /// or <c>null</c>.</param>
    /// <param name="options">One of the enumeration values, which specify whether or not
    /// line breaks are to be inserted into the return value. The default is 
    /// <see cref="Base64FormattingOptions.None" />.</param>
    /// <returns>The string representation of the elements in <paramref name="bytes" /> as
    /// Base64.</returns>
    /// <exception cref="ArgumentException"> <paramref name="options" /> is not a defined
    /// <see cref="Base64FormattingOptions" /> value.</exception>
    public static string Encode(IEnumerable<byte>? bytes,
                                Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        bytes ??= [];

        return bytes switch
        {
            byte[] arr => Convert.ToBase64String(arr, options),
#if NET5_0_OR_GREATER
            List<byte> list => Convert.ToBase64String(CollectionsMarshal.AsSpan(list), options),
#endif
            _ => Convert.ToBase64String([.. bytes], options),
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
#if NET462 || NETSTANDARD2_0
    {
        int length = bytes.Length;
        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        var arr = shared.Array;
        bytes.CopyTo(arr);
        return Convert.ToBase64String(arr, 0, length, options);
    }
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
        const int paddingPlaceholder = 2;

        base64 = base64.Trim();

        if (base64.IsEmpty)
        {
            return [];
        }

        char[]? arr = null;

        try
        {
            Span<char> contentSpan = default;

            if (options.HasFlag(Base64ParserOptions.AcceptBase64Url) && IsBase64Url(base64, out int replacementStartIndex))
            {
                int length = base64.Length;
                arr = ArrayPool<char>.Shared.Rent(length + paddingPlaceholder);
                contentSpan = arr.AsSpan(0, length);
                base64.CopyTo(contentSpan);

                int urlEncodedPaddingCount = ReplaceUrlEncodedPadding(ref contentSpan);
                ReplaceBase64UrlChars(contentSpan.Slice(replacementStartIndex,
                                                        contentSpan.Length - urlEncodedPaddingCount - replacementStartIndex));
                base64 = contentSpan;
            }

            int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding)
                                                ? GetMissingPaddingCount(base64)
                                                : 0;

            if (missingPaddingCount != 0)
            {
                if (arr is null)
                {
                    int length = base64.Length + missingPaddingCount;
                    arr = ArrayPool<char>.Shared.Rent(length);
                    contentSpan = arr.AsSpan(0, length);
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
        }
        finally
        {
            if (arr != null)
            {
                ArrayPool<char>.Shared.Return(arr, Confidentiality.IsConfidential);
            }
        }

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
                   switch
            { 0 => 0, 2 => 2, 3 => 1, _ => throw new FormatException() };
        }

        static bool IsBase64Url(ReadOnlySpan<char> base64, out int foundIndex)
        {
            // Look for the start of a URL-encoded padding char ("%3d"):
            if (base64.Length > 3 && base64[base64.Length - 3] == '%')
            {
                foundIndex = 0;
                return true;
            }

            foundIndex = base64.IndexOfAny("-_");
            return foundIndex != -1;
        }

        static int ReplaceUrlEncodedPadding(ref Span<char> span)
        {
            int urlEncodedPaddingCount = 0;

            ReadOnlySpan<char> tmp = span;

            // This is based on the assumption that Base64Url contains no white space -
            // neither URL-encoded nor unencoded.
            while (tmp.EndsWith(URL_ENCODED_PADDING, StringComparison.OrdinalIgnoreCase))
            {
                tmp = tmp.Slice(0, tmp.Length - 3);
                urlEncodedPaddingCount++;
            }

            if (urlEncodedPaddingCount != 0)
            {
                span = span.Slice(0, tmp.Length + urlEncodedPaddingCount);
                ApplyPadding(span, urlEncodedPaddingCount);
            }

            return urlEncodedPaddingCount;
        }

        static void ReplaceBase64UrlChars(Span<char> span)
        {
            for (int i = 0; i < span.Length; i++)
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
        return base64.IsEmpty ? [] : DoGetBytes(base64);
    }

    private static byte[] DoGetBytes(ReadOnlySpan<char> base64)
    {
        Debug.Assert(!base64.IsWhiteSpace());

#if NET462 || NETSTANDARD2_0
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(base64.Length);
        base64.CopyTo(shared.Array);

        return Convert.FromBase64CharArray(shared.Array, 0, base64.Length);
#else
        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>((base64.Length >> 2) * 3);
        Span<byte> byteSpan = shared.Array.AsSpan();

        return Convert.TryFromBase64Chars(base64, byteSpan, out int outputSize)
            ? byteSpan.Slice(0, outputSize).ToArray()
            : throw new FormatException();
#endif
    }

    internal static StringBuilder AppendEncodedTo(StringBuilder builder,
                                                  ReadOnlySpan<byte> bytes,
                                                  Base64FormattingOptions options)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if (bytes.Length == 0)
        {
            return builder;
        }

        int base64CharsCount = GetEncodedLength(bytes.Length);

        using ArrayPoolHelper.SharedArray<byte> byteBuf = ArrayPoolHelper.Rent<byte>(base64CharsCount);
        _ = Base64Bcl.EncodeToUtf8(bytes, byteBuf.Array.AsSpan(), out _, out _);

        using ArrayPoolHelper.SharedArray<char> charBuf = ArrayPoolHelper.Rent<char>(base64CharsCount);
        _ = Encoding.UTF8.GetChars(byteBuf.Array, 0, base64CharsCount, charBuf.Array, 0);

        if (options == Base64FormattingOptions.InsertLineBreaks)
        {
            bool insertNewLineAtStart = builder.Length != 0 && !builder[builder.Length - 1].IsNewLine();

            builder.EnsureCapacity(
                builder.Length
                + base64CharsCount + (base64CharsCount / LINE_LENGTH + 1) * LINE_BREAK.Length
                + (insertNewLineAtStart ? LINE_BREAK.Length : 0));

            if (insertNewLineAtStart)
            {
                _ = builder.AppendLine();
            }

            int end = base64CharsCount - LINE_LENGTH;
            int i = 0;

            for (; i < end; i += LINE_LENGTH)
            {
                _ = builder.Append(charBuf.Array, i, LINE_LENGTH)
                           .Append(LINE_BREAK);
            }

            return builder.Append(charBuf.Array, i, base64CharsCount - i);
        }
        else
        {
            builder.EnsureCapacity(builder.Length + base64CharsCount);
            return builder.Append(charBuf.Array, 0, base64CharsCount);
        }
    }
}
