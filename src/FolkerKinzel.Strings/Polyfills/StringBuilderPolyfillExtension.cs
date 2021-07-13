using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings.Polyfills
{
    public static class StringBuilderPolyfillExtension
    {
# if NET45 || NETSTANDARD2_0
        public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                _ = builder.Append(value[i]);
            }
            return builder;
        }
#endif
    }
}
