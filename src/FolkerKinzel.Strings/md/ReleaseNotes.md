- New extension methods:
```csharp
bool IsAsciiLetterLower(this char);
bool IsAsciiLetterUpper(this char);
bool IsAsciiDigit(this char);
bool IsAsciiLetterOrDigit(this char);
bool IsAsciiHexDigit(this char);
bool IsAsciiHexDigitLower(this char);
bool IsAsciiHexDigitUpper(this char);
bool IsBetween(this char, char, char)
```
.
- Obsolete extension methods:
```csharp
bool IsAsciiLowerCaseLetter(this char);
bool IsAsciiUpperCaseLetter(this char);
bool IsDecimalDigit(this char);
```

.

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.