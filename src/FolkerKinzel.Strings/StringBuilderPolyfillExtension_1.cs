using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="StringBuilder" /> class, which are
/// used in .NET Framework 4.5 and .NET Standard 2.0 as polyfills for methods from current
/// .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the original methods of the <see cref="string" /> class, which exist
/// in more modern frameworks. To match the behavior of the original methods, these extension
/// methods throw a <see cref="NullReferenceException" /> when called on <c>null</c>.</remarks>
public static partial class StringBuilderPolyfillExtension { }