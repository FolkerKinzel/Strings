using System;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings.Intls;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Show as polyfill")]
internal class _ArgumentOutOfRangeException
{
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    internal static void ThrowIfNegative(int value, string paramName)
#if NET8_0_OR_GREATER
        => ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
    { if (value < 0) { throw new ArgumentOutOfRangeException(paramName); } }
#endif

}
