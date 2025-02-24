using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="TextWriter" /> class, which are
/// used in .NET Framework and .NET Standard 2.0 as polyfills for methods from current
/// .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the original methods of the <see cref="TextWriter" /> class, which exist
/// in more modern frameworks. To match the behavior of the original methods, these extension
/// methods throw a <see cref="NullReferenceException" /> when called on <c>null</c>.
/// </remarks>
public static class TextWriterPolyfillExtension
{
    /// <summary>
    /// Writes the text representation of a character span to the text stream.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter"/> to use.</param>
    /// <param name="buffer">The char span value to write to the text stream.</param>
    /// <exception cref="NullReferenceException"> <paramref name="writer"/> is <c>null</c>.
    /// </exception>
#if NET462 || NETSTANDARD2_0
    public static void Write(this TextWriter writer, ReadOnlySpan<char> buffer)
    {
        _NullReferenceException.ThrowIfNull(writer, nameof(writer));

        if (writer is StringWriter sw)
        {
            _ = sw.GetStringBuilder().Append(buffer);
        }
        else
        {
            using ArrayPoolHelper.SharedArray<char> 
                            shared = ArrayPoolHelper.Rent<char>(buffer.Length);
            buffer.CopyTo(shared.Array);
            writer.Write(shared.Array, 0, buffer.Length);
        }
    }
#else
    public static void Write(TextWriter writer,
                             ReadOnlySpan<char> buffer) => writer.Write(buffer);
#endif

    /// <summary>
    /// Writes the text representation of a character span to the text stream, 
    /// followed by <see cref="TextWriter.NewLine"/>.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter"/> to use.</param>
    /// <param name="span">The char span value to write to the text stream.</param>
    /// <exception cref="NullReferenceException"> <paramref name="writer"/> is <c>null</c>.
    /// </exception>
#if NET462 || NETSTANDARD2_0
    public static void WriteLine(this TextWriter writer, ReadOnlySpan<char> span)
    {
        writer.Write(span);
        writer.WriteLine();
    }
#else
    public static void WriteLine(TextWriter writer,
                                 ReadOnlySpan<char> span) => writer.WriteLine(span);
#endif
}
