# FolkerKinzel.Strings

## Extension Methods, which Simulate String.Trim() on the StringBuilder Class
```csharp
// Trim:
public static StringBuilder Trim(this StringBuilder builder);
public static StringBuilder Trim(this StringBuilder builder, char trimChar);
public static StringBuilder Trim(this StringBuilder builder, params char[]? trimChars)

// TrimStart:
public static StringBuilder TrimStart(this StringBuilder builder);
public static StringBuilder TrimStart(this StringBuilder builder, char trimChar);
public static StringBuilder TrimStart(this StringBuilder builder, params char[]? trimChars);


// TrimEnd:
public static StringBuilder TrimEnd(this StringBuilder builder);
public static StringBuilder TrimEnd(this StringBuilder builder, char trimChar);
public static StringBuilder TrimEnd(this StringBuilder builder, params char[]? trimChars);
```