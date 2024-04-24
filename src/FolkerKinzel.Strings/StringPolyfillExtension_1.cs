using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 ||  NETCOREAPP3_1 || NET5_0 

/// <summary>Extension methods for the <see cref="string" /> class, which are used
/// as polyfills for methods from current .NET versions.</summary>
/// <remarks>To match the behavior of the original methods, these extension methods throw
/// a <see cref="NullReferenceException" /> when called on a <c>null</c> string.</remarks>
public static partial class StringPolyfillExtension { }

#endif


