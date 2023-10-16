namespace FolkerKinzel.Strings.Polyfills;

    /// <summary>Extension methods for the <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>
    /// structure, which are used in .NET Framework 4.5, .NET Standard 2.0 and .NET Standard
    /// 2.1 as polyfills for methods from current .NET versions.</summary>
    /// <remarks>The methods of this class should only be used in the extension method syntax
    /// to simulate the methods of the <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>
    /// structure, which exist in more modern frameworks.</remarks>
public static class ReadOnlyMemoryPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 and above have an empty class!
#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1

    /// <summary>Removes all leading and trailing white space characters from a read-only
    /// character memory region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
    public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
    {
        ReadOnlySpan<char> span = memory.Span;
        int start = span.GetTrimmedStart();
        int length = span.Slice(start).GetTrimmedLength();
        return memory.Slice(start, length);
    }

    /// <summary>Removes all leading white space characters from a read-only character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
    public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory)
        => memory.Slice(memory.Span.GetTrimmedStart());

    /// <summary>Removes all trailing white space characters from a read-only character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
    public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory)
        => memory.Slice(0, memory.Span.GetTrimmedLength());

#endif
}
