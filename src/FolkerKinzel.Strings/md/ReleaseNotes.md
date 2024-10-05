Fixes an issue that occurs if the library is used as a transitive dependency and the direct dependency supports 
the framework of the application only indirectly, e.g., with .NET Standard.
In order to achieve this, small API-changes where required: The class `FolkerKinzel.Strings.SearchValues` 
has been renamed to `SearchValuesPolyfill`. `FolkerKinzel.SpanAction` has been replaced by `System.Buffers.SpanAction`.

**Despite these breaking changes, it is strongly recommended to install the update.**
&nbsp;
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.