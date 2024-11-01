using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>
/// Enumerates the lines of a read-only character span.
/// </summary>
/// <remarks>
/// To get an instance of this type, use <see cref="ReadOnlySpanPolyfillExtension.EnumerateLines(ReadOnlySpan{char})"/>.
/// </remarks>
public ref struct SpanLineEnumeratorPolyfill
{
    private ReadOnlySpan<char> _remaining;
    private ReadOnlySpan<char> _current;
    private bool _isEnumeratorActive;

    internal SpanLineEnumeratorPolyfill(ReadOnlySpan<char> buffer)
    {
        _remaining = buffer;
        _current = default;
        _isEnumeratorActive = true;
    }

    /// <summary>
    /// Gets the line at the current position of the enumerator.
    /// </summary>
    public readonly ReadOnlySpan<char> Current => _current;

    /// <summary>
    /// Returns this instance as an enumerator.
    /// </summary>
    /// <returns>
    /// A <see cref="SpanLineEnumeratorPolyfill"/> to enumerate the lines.
    /// </returns>
    public readonly SpanLineEnumeratorPolyfill GetEnumerator() => this;

    /// <summary>
    /// Advances the enumerator to the next line of the span.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the enumerator successfully advanced to the next line; <c>false</c> if
    /// the enumerator has advanced past the end of the span.
    /// </returns>
    public bool MoveNext()
    {
        if (!_isEnumeratorActive)
        {
            return false; // EOF previously reached or enumerator was never initialized
        }

        ReadOnlySpan<char> remaining = _remaining;

        int idx = ReadOnlySpanPolyfillExtension.IndexOfAny(remaining, SearchValuesStorage.NewLineChars);

        if ((uint)idx < (uint)remaining.Length)
        {
            int stride = 1;

            if (remaining[idx] == '\r' && (uint)(idx + 1) < (uint)remaining.Length && remaining[idx + 1] == '\n')
            {
                stride = 2;
            }

            _current = remaining.Slice(0, idx);
            _remaining = remaining.Slice(idx + stride);
        }
        else
        {
            // We've reached EOF, but we still need to return 'true' for this final
            // iteration so that the caller can query the Current property once more.

            _current = remaining;
            _remaining = default;
            _isEnumeratorActive = false;
        }

        return true;
    }
}