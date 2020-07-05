# Strings
.NET library, containing extension methods for System.String and System.Text.StringBuilder.

##### Content:
* Extension methods, that produce constant integer hash codes for constant strings (or constant StringBuilder content). The hash codes can be specified to hash the string ordinal, ordinal case insensitive or alphanumeric case insensitiv. The hash codes produced by this library are not equivalent to the hash codes produced by .NET-Framework 4.0, because they use roundshifting to keep more information.  Don't use constant hash codes for security critical purposes!
