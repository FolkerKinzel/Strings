#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0
using FolkerKinzel.Strings;

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace System.Text
{
    /// <summary>
    /// Enumerates the lines of a <see cref="ReadOnlySpan{Char}"/>.
    /// </summary>
    /// <remarks>
    /// To get an instance of this type, use <see cref="MemoryExtensions.EnumerateLines(ReadOnlySpan{char})"/>.
    /// </remarks>
    public ref struct SpanLineEnumerator
    {
        private const string NEW_LINE_CHARS = "\r\n\f\u0085\u2028\u2029";
        private ReadOnlySpan<char> _remaining;
        private ReadOnlySpan<char> _current;
        private bool _isEnumeratorActive;

        internal SpanLineEnumerator(ReadOnlySpan<char> buffer)
        {
            _remaining = buffer;
            _current = default;
            _isEnumeratorActive = true;
        }

        /// <summary>
        /// Gets the line at the current position of the enumerator.
        /// </summary>
        public ReadOnlySpan<char> Current => _current;

        /// <summary>
        /// Returns this instance as an enumerator.
        /// </summary>
        public SpanLineEnumerator GetEnumerator() => this;

        /// <summary>
        /// Advances the enumerator to the next line of the span.
        /// </summary>
        /// <returns>
        /// True if the enumerator successfully advanced to the next line; false if
        /// the enumerator has advanced past the end of the span.
        /// </returns>
#if NET5_0
        [SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters",
            Justification = "Not localizable")]
#endif
        public bool MoveNext()
        {
            if (!_isEnumeratorActive)
            {
                return false; // EOF previously reached or enumerator was never initialized
            }

            ReadOnlySpan<char> remaining = _remaining;

            int idx = MemoryExtensions.IndexOfAny(remaining, NEW_LINE_CHARS.AsSpan());

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
}
#endif