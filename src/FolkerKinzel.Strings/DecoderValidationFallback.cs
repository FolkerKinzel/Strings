using System.ComponentModel;

namespace FolkerKinzel.Strings;

    /// <summary> Stellt einen als Fallback bezeichneten Fehlerbehandlungsmechanismus für
    /// eine codierte Eingabebytefolge bereit, die nicht in ein Ausgabezeichen konvertiert
    /// werden kann. Das Fallback gibt ein Ersatzzeichen (⬜) anstelle einer decodierten Eingabebytefolge
    /// aus und informiert in seiner Eigenschaft <see cref="HasError" /> darüber, ob ein
    /// Fehler aufgetreten ist. </summary>
    /// <remarks>
    /// <para>
    /// Verwenden Sie <see cref="DecoderValidationFallback" />-Objekte in den Methoden
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <see cref="Encoding.GetEncoding(int, EncoderFallback, DecoderFallback)"> Encoding.GetEncoding(int,
    /// EncoderFallback, DecoderFallback)</see>,
    /// </item>
    /// <item>
    /// <see cref="Encoding.GetEncoding(string, EncoderFallback, DecoderFallback)"> Encoding.GetEncoding(string,
    /// EncoderFallback, DecoderFallback)</see> oder
    /// </item>
    /// <item>
    /// <see cref="TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback,
    /// bool)"> TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback,
    /// bool)</see> und
    /// </item>
    /// <item>
    /// <see cref="TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback,
    /// bool)"> TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback,
    /// bool)</see>.
    /// </item>
    /// </list>
    /// <para>
    /// Das <see cref="DecoderValidationFallback" />-Objekt wird dabei als <see cref="DecoderFallback"
    /// />-Objekt übergeben.
    /// </para>
    /// <para>
    /// Die <see cref="DecoderValidationFallback" />-Klasse verhält sich wie die Klasse <see
    /// cref="DecoderReplacementFallback" />, mit dem Unterschied, dass sie in ihrer Eigenschaft
    /// <see cref="HasError" /> nach Benutzung darüber informiert, ob ein Fehler aufgetreten
    /// ist. Zur Auswertung der Eigenschaft, sollten Sie eine Referenz auf das <see cref="DecoderValidationFallback"
    /// />-Objekt behalten oder den Rückgabewert der Eigenschaft <see cref="Encoding.DecoderFallback">Encoding.DecoderFallback</see>
    /// in den Typ <see cref="DecoderValidationFallback" /> casten.
    /// </para>
    /// <para>
    /// Wenn Sie das <see cref="DecoderValidationFallback" />-Objekt mehrfach verwenden,
    /// können sie die Eigenschaft <see cref="HasError" /> mit der Methode <see cref="Reset"
    /// /> zurücksetzen.
    /// </para>
    /// </remarks>
public sealed class DecoderValidationFallback : DecoderFallback
{
    private readonly ValidatorFallbackBuffer _buffer = new();

    /// <summary>Indicates whether a decoding error occurred.</summary>
    /// <value> <c>true</c> if an error occurred, <c>false</c> otherwise.</value>
    public bool HasError => _buffer.HasError;

    /// <summary> Setzt die Eigenschaft <see cref="HasError" /> auf ihren Ausgangswert <c>false</c>
    /// zurück. </summary>
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
            char result = _finished ? '\0' : '\u2B1C';
            _finished = true;
            return result;
        }

        public override bool MovePrevious() => false;
    }
}
