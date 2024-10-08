﻿using System.Runtime.InteropServices;

namespace FolkerKinzel.Strings.Intls;

internal static class CollectionConverter
{
    internal static ReadOnlySpan<T> AsSpan<T>(this IEnumerable<T>? coll)
    {
        ReadOnlySpan<T> span = coll switch
        {
            T[] arr => arr,
#if NET5_0_OR_GREATER
            List<T> list => CollectionsMarshal.AsSpan(list),
#endif
            IEnumerable<T> => coll.ToArray(),
            _ => []
        };

        return span;
    }
}