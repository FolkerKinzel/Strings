namespace FolkerKinzel.Strings;

#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

/// <summary>Extension methods for the <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>
/// struct, which are used as polyfills for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>
/// struct, which exist in more modern frameworks.</remarks>
public static partial class ReadOnlySpanPolyfillExtension { }

#endif
