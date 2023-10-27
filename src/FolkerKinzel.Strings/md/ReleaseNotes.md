- New method overloads:
```csharp
int string.IndexOfAny(ReadOnlySpan<char>, int);
int string.IndexOfAny(ReadOnlySpan<char>);
int string.LastIndexOfAny(ReadOnlySpan<char>, int);
int string.LastIndexOfAny(ReadOnlySpan<char>);
```
- New polyfills for the String class (.NET Standard 2.0, .NET Framework 4.5)
```csharp
int string.IndexOfAny(string?, int);
int string.IndexOfAny(string?);
int string.LastIndexOfAny(string?, int);
int string.LastIndexOfAny(string?);
bool string.ContainsAny(string?);
```
- Performance optimization

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.