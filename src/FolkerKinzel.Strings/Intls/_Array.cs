namespace FolkerKinzel.Strings.Intls;


[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
internal static class _Array
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static T[] Empty<T>()
#if NET45
        => new T[0];
#else
        => Array.Empty<T>();
#endif
}
