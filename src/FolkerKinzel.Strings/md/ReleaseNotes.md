- **Breaking change:** Added a .NET Core 3.1 DLL to the nuget package and removed the namespace 
`FolkerKinzel.Strings.Polyfills` instead. 

>The namespace FolkerKinzel.Strings.Polyfills was a
compromise solution because some extension methods from this namespace caused conflicts with the extension
methods from System.MemoryExtensions in .NET Core 3.1 projects. The namespace allowed to hide the polyfills in 
.NET Core 3.1. On the other hand this solution was quite bad because users could forget to 
publish this namespace in other projects and lost the chance to use the polyfills. Having a .NET Core 3.1 DLL
as part of the nuget package is much more elegant: Only one namespace (`FolkerKinzel.Strings`) is needed to use the
whole package.
- **Breaking Change:** The .NET Framework 4.5 support has ended. A .NET Framework 4.6.1 DLL is part of the nuget package instead.
- **Breaking Change:** Removed the obsolete method `StringBuilder.NormalizeNewLinesTo`.
- **Breaking Change:** Removed the obsolete method `String.NormalizeNewLinesTo`.
- Deterministic build
- Performance: Raised the maximum allowed stackalloc size for Char to 256 (according to the internal constant 
`System.String.StackallockCharBufferSizeLimit`) from the .NET sources and for Byte to 512.
- Performance: Faster algorithm for `Base64.GetEncodedLength(int)` (taken from `System.Buffers.Text.Base64`).
- Performance: Faster and more memory efficient algorithm for StringBuilder.AppendBase64 when options is
Base64FormattingOptions.InsertLineBreaks
- Performance: Higher memory efficiency in polyfills by using ArrayPool&lt;T&gt;.Shared. For security-critical 
applications the new class `Confidentiality` allows to control whether shared arrays are emptied when returned.

- New extension methods:
```csharp
int GetTrimmedStart(this ReadOnlySpan<char>, char);
int GetTrimmedStart(this Span<char>, char);
int GetTrimmedLength(this ReadOnlySpan<char>, char);
int GetTrimmedLength(this Span<char>, char);
```
&nbsp;
- New Polyfills for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1):
```csharp
Span<char> Trim(this Span<char>, char);
Span<char> TrimStart(this Span<char>, char);
Span<char> TrimEnd(this Span<char>, char);
```
&nbsp;
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.