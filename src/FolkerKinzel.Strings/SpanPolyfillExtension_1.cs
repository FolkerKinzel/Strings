namespace FolkerKinzel.Strings;

#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

/// <summary>Extension methods for the <see cref="Span{T}">Span&lt;Char&gt;</see> struct
/// used in the .NET Framework 4.5, .NET Standard 2.0, and .NET Standard 2.1 as polyfills
/// for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="Span{T}">Span&lt;Char&gt;</see> struct,
/// which exist in current frameworks.</remarks>
public static partial class SpanPolyfillExtension { }

#endif

