- .NET 8.0 support
- Dependency update

- New polyfill for the ReadOnlySpan&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0):
```csharp
int IndexOf(this ReadOnlySpan<char>, string?, StringComparison);
```
.
- New extension method for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)
```csharp
int IndexOf(this Span<char>, ReadOnlySpan<char>, StringComparison);
```
.
- New polyfill for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
int IndexOf(this Span<char>, string?, StringComparison);
```
.

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.