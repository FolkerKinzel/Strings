using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings.Intls;

/// <summary>
/// Provides methods to examine data in order to see whether it is UTF-8 text.
/// </summary>
internal sealed class Utf8Validator
{
    private const int CODEPAGE_UTF8 = 65001;
    private readonly Encoding _encoding;

    private readonly DecoderValidationFallback _fallback = new();
    private const int EOF = -1;

    private bool HasError => _fallback.HasError;


    /// <summary>
    /// ctor
    /// </summary>
    public Utf8Validator() => _encoding = Encoding.GetEncoding(CODEPAGE_UTF8,
                                                              EncoderFallback.ReplacementFallback,
                                                              _fallback);


    /// <summary>
    /// Tests whether the byte sequence of <paramref name="stream"/> that starts with the current <see cref="Stream.Position"/>
    /// and is at least <paramref name="count"/> characters long is UTF-8 text. The method takes the Byte Order Mark (BOM)
    /// into account.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to examine.</param>
    /// <param name="count">The number of characters to examine at least. If 
    /// <paramref name="count"/> is larger than <paramref name="stream"/> has data, <paramref name="stream"/> is
    /// examined until EOF. Passing a negative number to this parameter lets the method examine the whole 
    /// <paramref name="stream"/> from the current
    /// position until EOF. Passing <c>0</c> lets the method examine the BOM only.</param>
    /// <param name="leaveOpen"><c>false</c> to let the method close the <paramref name="stream"/>, <c>true</c> 
    /// otherwise.</param>
    /// <returns><c>true</c> if <paramref name="stream"/> might be UTF-8 text, otherwise <c>false</c>.
    /// If the method finds a UTF-8 BOM, it always returns <c>true</c>. If <paramref name="count"/> is 
    /// <c>0</c> and there's no BOM, it returns <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <c>null</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="stream"/> was already
    /// closed.</exception>
    /// <exception cref="NotSupportedException"><paramref name="stream"/> is not readable or <paramref name="stream"/>
    /// does not support seek operations.</exception>
    [SuppressMessage("Style", "IDE0078:Musterabgleich verwenden (kann Codebedeutung ändern)", Justification = "<Ausstehend>")]
    public bool IsUtf8(Stream stream, int count, bool leaveOpen)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        _fallback.Reset();
        long position = stream.Position;

        if (ParseBom(stream))
        {
            if (!leaveOpen) { stream.Close(); }
            return true;
        }
        if (count == 0)
        {
            return false;
        }
        stream.Position = position;

        return DoIsValidUtf8(stream, InitCount(count), leaveOpen);

        /////////////////////////////////

        static bool ParseBom(Stream stream) =>
            stream.ReadByte() == 0xEF &&
            stream.ReadByte() == 0xBB &&
            stream.ReadByte() == 0xBF;
    }


    /// <summary>
    /// Tests whether the <see cref="byte"/> sequence of <paramref name="stream"/> that starts with the current 
    /// <see cref="Stream.Position"/>
    /// and is at least <paramref name="count"/> characters long is valid UTF-8 text.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to examine.</param>
    /// <param name="count">The number of characters to examine from the <paramref name="stream"/> at least. If 
    /// <paramref name="count"/> is larger than <paramref name="stream"/> has data, <paramref name="stream"/> is
    /// examined until EOF. Passing a negative number to this parameter lets the method examine from the current
    /// position until EOF. <c>0</c> is not allowed.</param>
    /// <param name="leaveOpen"><c>false</c> to let the method close the <paramref name="stream"/>, <c>true</c> 
    /// otherwise.</param>
    /// <returns><c>true</c> if the examined sequence in <paramref name="stream"/> is valid UTF-8 text, otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is <c>0</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="stream"/> was already
    /// closed.</exception>
    /// <exception cref="NotSupportedException"><paramref name="stream"/> is not readable.</exception>
    public bool IsUtf8Valid(Stream stream, int count, bool leaveOpen)
    {
        _ = stream ?? throw new ArgumentNullException(nameof(stream));
        return DoIsValidUtf8(stream, InitCount(count), leaveOpen);
    }

    private bool DoIsValidUtf8(Stream stream, long count, bool leaveOpen)
    {
        Debug.Assert(stream != null);
        Debug.Assert(count != 0);

        _fallback.Reset();
        using StreamReader reader = InitStreamReader(stream, leaveOpen: leaveOpen);

        int i;
        while (count-- > 0 && (i = reader.Read()) != EOF)
        {
            if (HasError)
            {
                return false;
            }
        }
        return !HasError;
    }


    private StreamReader InitStreamReader(Stream stream, bool leaveOpen)
    {
        return new(stream, _encoding, bufferSize: 128, detectEncodingFromByteOrderMarks: false,
             leaveOpen: leaveOpen);
    }


    private static long InitCount(int count) =>
        count < 0 ? long.MaxValue 
                  : count == 0 ? throw new ArgumentOutOfRangeException(nameof(count), Res.ZeroNotAllowed) 
                               : count;
}
