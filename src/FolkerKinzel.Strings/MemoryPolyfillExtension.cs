namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="Memory{T}">Memory&lt;Char&gt;</see>
/// struct, which are used in .NET Framework 4.6.1, .NET Standard 2.0 and .NET Standard
/// 2.1 as polyfills for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="Memory{T}">Memory&lt;Char&gt;</see>
/// struct, which exist in more modern frameworks.</remarks>
public static class MemoryPolyfillExtension
{
    /// <summary>Removes all leading and trailing white space characters from
    /// character memory region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Memory<char> Trim(this Memory<char> memory)
        => memory.TrimStart().TrimEnd();
#else
    public static Memory<char> Trim(Memory<char> memory)
        => MemoryExtensions.Trim(memory);
#endif

    /// <summary>Removes all leading white space characters from a character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Memory<char> TrimStart(this Memory<char> memory)
        => memory.Slice(memory.Length - ((ReadOnlySpan<char>)memory.Span).TrimStart().Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Memory<char> TrimStart(Memory<char> memory)
        => MemoryExtensions.TrimStart(memory);
#endif

    /// <summary>Removes all trailing white space characters from a character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Memory<char> TrimEnd(this Memory<char> memory)
        => memory.Slice(0, ((ReadOnlySpan<char>)memory.Span).TrimEnd().Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Memory<char> TrimEnd(Memory<char> memory)
        => MemoryExtensions.TrimEnd(memory);
#endif
}
