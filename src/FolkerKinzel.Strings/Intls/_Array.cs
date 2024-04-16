namespace FolkerKinzel.Strings.Intls;


[SuppressMessage("Style", "IDE1006:Naming Styles", 
    Justification = "Show as polyfill")]
internal static class _Array
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static T[] Empty<T>()
#if NET45
        => [];
#else
#pragma warning disable IDE0301 // Simplify collection initialization
        => Array.Empty<T>();
#pragma warning restore IDE0301 // Simplify collection initialization
#endif
}
