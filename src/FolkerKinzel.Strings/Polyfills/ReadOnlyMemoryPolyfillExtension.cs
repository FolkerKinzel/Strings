using System;
using System.Collections.Generic;
using System.Text;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings.Polyfills
{
    
    public static class ReadOnlyMemoryPolyfillExtension
    {
        # if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1  
        /// <summary>
        /// Removes all leading and trailing white-space characters from the memory.
        /// </summary>
        /// <param name="memory">The source memory from which the characters are removed.</param>
        public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
        {
            ReadOnlySpan<char> span = memory.Span;
            int start = span.ClampStart();
            int length = span.ClampEnd(start);
            return memory.Slice(start, length);
        }
 
        /// <summary>
        /// Removes all leading white-space characters from the memory.
        /// </summary>
        /// <param name="memory">The source memory from which the characters are removed.</param>
        public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory)
            => memory.Slice(memory.Span.ClampStart());
 
        /// <summary>
        /// Removes all trailing white-space characters from the memory.
        /// </summary>
        /// <param name="memory">The source memory from which the characters are removed.</param>
        public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory)
            => memory.Slice(0, memory.Span.ClampEnd(0));

        #endif
    }
}
