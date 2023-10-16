using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings.Intls;

[SuppressMessage("Style", "IDE1006:Benennungsstile", Justification = "<Ausstehend>")]
internal class _Array
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static T[] Empty<T>()
#if NET45
        => new T[0];
#else
        => Array.Empty<T>();
#endif
}
