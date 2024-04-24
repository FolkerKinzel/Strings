using System.ComponentModel;

namespace FolkerKinzel.Strings;

/// <summary> 
/// Provides a failure-handling mechanism, called a fallback, for an encoded input byte
/// sequence that cannot be converted to an output character. The fallback emits a replacement
/// character � (U+FFFD, "REPLACEMENT CHARACTER") instead of a decoded input byte sequence 
/// and informs in its property <see cref="HasError" /> whether an error has occurred.</summary>
/// <remarks>
/// <para>
/// Use <see cref="DecoderValidationFallback" /> objects with the methods 
/// </para>
/// <list type="bullet">
/// <item>
/// <see cref="Encoding.GetEncoding(int, EncoderFallback, DecoderFallback)"> Encoding.GetEncoding(int,
/// EncoderFallback, DecoderFallback)</see>,
/// </item>
/// <item>
/// <see cref="Encoding.GetEncoding(string, EncoderFallback, DecoderFallback)"> 
/// Encoding.GetEncoding(string, EncoderFallback, DecoderFallback)</see> or
/// </item>
/// <item>
/// <see cref="TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback, bool)">
/// TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback, bool)</see> and
/// </item>
/// <item>
/// <see cref="TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback, bool)">
/// TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback, bool)</see>.
/// </item>
/// </list>
/// <para>
/// The <see cref="DecoderValidationFallback" /> object is passed as a <see cref="DecoderFallback" /> 
/// object.
/// </para>
/// <para>
/// The <see cref="DecoderValidationFallback" /> class behaves like the <see cref="DecoderReplacementFallback" /> 
/// class, except that it informs after use in its  <see cref="HasError" /> property whether an error has 
/// occurred. To evaluate the property, You should keep a reference to the <see cref="DecoderValidationFallback" /> 
/// object or cast the return value of the <see cref="Encoding.DecoderFallback">Encoding.DecoderFallback</see>
/// property to the Type <see cref="DecoderValidationFallback" />.
/// </para>
/// <para>
/// When using the <see cref="DecoderValidationFallback" /> object multiple times, the <see cref="Reset" /> 
/// method can be called to reset the <see cref="HasError" /> property.
/// </para>
/// </remarks>
public sealed class DecoderValidationFallback : DecoderFallback
{
    private readonly ValidatorFallbackBuffer _buffer = new();

    /// <summary>Indicates whether a decoding error occurred.</summary>
    /// <value> <c>true</c> if an error occurred, <c>false</c> otherwise.</value>
    public bool HasError => _buffer.HasError;

    /// <summary> 
    /// Resets the <see cref="HasError" /> property to its initial value <c>false</c>.
    /// </summary>
    public void Reset() => _buffer.ResetError();

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int MaxCharCount => 1;

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override DecoderFallbackBuffer CreateFallbackBuffer() => _buffer;

    /// ///////////////////////////////////////////////////////////////

    private sealed class ValidatorFallbackBuffer : DecoderFallbackBuffer
    {
        private bool _finished = false;

        public bool HasError { get; private set; }

        public void ResetError() => HasError = false;

        public override void Reset() { }

        public override int Remaining => 0;

        public override bool Fallback(byte[] bytesUnknown, int index)
        {
            _finished = false;
            HasError = true;
            return true;
        }

        public override char GetNextChar()
        {
            char result = _finished ? '\0' : '\uFFFD';
            _finished = true;
            return result;
        }

        public override bool MovePrevious() => false;
    }
}
