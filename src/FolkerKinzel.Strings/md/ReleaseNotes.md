- Performance: Raises the maximum allowed stackalloc size to 256 (according to the internal constant `System.String.StackallockCharBufferSizeLimit`) from the .NET sources.
- Performance: Faster algorithm for `Base64.GetEncodedLength(int)` (taken from `System.Buffers.Text.Base64`).
- Removed the namespace `FolkerKinzel.Strings.Polyfills`
- Added .NET Core 3.1 to the nuget package
.

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.