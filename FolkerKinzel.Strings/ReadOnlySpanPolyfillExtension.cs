using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings
{
    public static class ReadOnlySpanPolyfillExtension
    {
#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1

        public static bool Contains<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
        {
            for (int i = 0; i < span.Length; i++)
            {
                if(span[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
#endif

        //public static bool StartsWith<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
        //    => !span.IsEmpty && span[0].Equals(value);
    }
}
