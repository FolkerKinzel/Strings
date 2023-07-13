using System.ComponentModel;

namespace FolkerKinzel.Strings;

/// <summary>
/// Stellt einen als Fallback bezeichneten Fehlerbehandlungsmechanismus für eine codierte Eingabebytefolge bereit, 
/// die nicht in ein Ausgabezeichen konvertiert werden kann. Der Fallback gibt eine benutzerdefinierte Ersatzzeichenfolge
/// anstelle einer decodierten Eingabebytefolge aus und informiert in ihrer Eigenschaft <see cref="HasError"/> darüber,
/// ob ein Fehler aufgetreten ist.
/// </summary>
public sealed class DecoderValidationFallback : DecoderFallback
{
    private readonly ValidatorFallbackBuffer _buffer = new();

    public bool HasError => _buffer.HasError;

    public void Reset() => _buffer.ResetError();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int MaxCharCount => 1;

    /// <inheritdoc/>
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
            char result = _finished ? '\0' : '?';
            _finished = true;
            return result;
        }

        public override bool MovePrevious() => false;

        
    }
}
