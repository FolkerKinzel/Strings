# FolkerKinzel.Strings 2.1.0
## Package Release Notes

- Added a Polyfill for .NET Framework and .NET Standard 2.0:
```csharp
public static bool Contains(this string s, char value);
```
.
- New Overloads of the StringBuilder.Trim Methods:
```csharp
public static StringBuilder Trim(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimStart(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars);
```
.

- New extension methods for the System.String class:
```csharp
public static string Trim(this string s, ReadOnlySpan<char> trimChars)
public static string TrimStart(this string s, ReadOnlySpan<char> trimChars)
public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
```
