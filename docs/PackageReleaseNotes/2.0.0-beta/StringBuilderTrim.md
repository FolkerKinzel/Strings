# FolkerKinzel.Strings

## Extension methods that simulate String.Trim() on the StringBuilder class
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
public static StringBuilder TrimEnd(this StringBuilder stringBuilder);
public static StringBuilder TrimEnd(this StringBuilder stringBuilder, char trimChar);
public static StringBuilder TrimEnd(this StringBuilder stringBuilder, params char[]? trimChars);
```