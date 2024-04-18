namespace FolkerKinzel.Strings.Intls;

[SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Show as polyfill")]
internal static class _ArgumentNullException
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNull([NotNull] object? argument, string paramName)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1  || NETCOREAPP3_1 || NET5_0
    { if (argument is null) { throw new ArgumentNullException(paramName); } }
#else
        => ArgumentNullException.ThrowIfNull(argument, paramName);
#endif
}
