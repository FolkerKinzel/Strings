namespace FolkerKinzel.Strings.Intls;

[SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Show as polyfill")]
internal static class _ArgumentNullException
{
#if NET6_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    internal static void ThrowIfNull([NotNull] object? argument, string paramName)
#if NET6_0_OR_GREATER
        => ArgumentNullException.ThrowIfNull(argument, paramName);
#else
    { if (argument is null) { throw new ArgumentNullException(paramName); } }
#endif

    //[DoesNotReturn]
    //internal static void Throw(string paramName)
    //    => throw new ArgumentNullException(paramName);
}
