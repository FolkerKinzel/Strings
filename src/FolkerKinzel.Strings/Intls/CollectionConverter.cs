using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FolkerKinzel.Strings.Intls;

internal static class CollectionConverter
{

    internal static ReadOnlySpan<T> ToReadOnlySpan<T>(IEnumerable<T> coll)
    {
        Debug.Assert(coll != null);

        ReadOnlySpan<T> span = coll switch
        {
            T[] arr => arr,
#if NET5_0_OR_GREATER
            List<T> list => CollectionsMarshal.AsSpan(list),
#endif
            _ => coll.ToArray(),
        };
        return span;
    }
}