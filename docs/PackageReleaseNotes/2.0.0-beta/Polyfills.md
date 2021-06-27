# FolkerKinzel.Strings

## List of Polyfill Extension Methods

### Polyfills for the String Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
public static bool Contains(this string s, char value, StringComparison comparisonType);
public static int IndexOf(this string s, char value, StringComparison comparisonType);
public static string[] Split(this string s, char separator, StringSplitOptions options = StringSplitOptions.None);
public static string[] Split(this string s, char separator, int count, StringSplitOptions options = StringSplitOptions.None);
public static bool StartsWith(this string s, char value);
public static bool EndsWith(this string s, char value);
```
.

### Polyfills for the ReadOnlySpan&lt;T&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
public static bool Contains<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
```