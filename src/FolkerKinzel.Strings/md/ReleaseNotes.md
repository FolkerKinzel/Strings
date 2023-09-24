- The usage of the following methods will produce an obsolete error instead of a warning now:
```csharp
bool IsAsciiLowerCaseLetter(this char);
bool IsAsciiUpperCaseLetter(this char);
bool IsDecimalDigit(this char);
bool IsHexDigit(this char);
```
The library contains better replacements for all of these methods.


> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.