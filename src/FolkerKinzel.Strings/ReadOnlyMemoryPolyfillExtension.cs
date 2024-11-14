namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>
/// struct, which are used in .NET Framework 4.6.1, .NET Standard 2.0 and .NET Standard
/// 2.1 as polyfills for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>
/// struct, which exist in more modern frameworks.</remarks>
public static class ReadOnlyMemoryPolyfillExtension
{
    /// <summary>Removes all leading and trailing white space characters from a read-only
    /// character memory region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
        => memory.TrimStart().TrimEnd();
#else
    public static ReadOnlyMemory<char> Trim(ReadOnlyMemory<char> memory)
        => MemoryExtensions.Trim(memory);
#endif

    /// <summary>Removes all leading white space characters from a read-only character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory)
        => memory.Slice(memory.Length - memory.Span.TrimStart().Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyMemory<char> TrimStart(ReadOnlyMemory<char> memory)
        => MemoryExtensions.TrimStart(memory);
#endif

    /// <summary>Removes all trailing white space characters from a read-only character memory
    /// region.</summary>
    /// <param name="memory">The source memory from which the characters are removed.</param>
    /// <returns>The trimmed character memory region.</returns>
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory)
        => memory.Slice(0, memory.Span.TrimEnd().Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyMemory<char> TrimEnd(ReadOnlyMemory<char> memory)
        => MemoryExtensions.TrimEnd(memory);
#endif
}

