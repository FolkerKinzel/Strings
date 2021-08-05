using System;
using System.Diagnostics;

namespace FolkerKinzel.Strings.Intls
{
    # if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1  
    internal static class TrimHelper
    {
        //internal static int GetLength(ReadOnlySpan<char> span, char trimChar)
        //{
        //    int length = span.Length;

        //    while (length > 0)
        //    {
        //        if (span[length - 1] == trimChar)
        //        {
        //            --length;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    return length;
        //}


        //internal static int GetStart(ReadOnlySpan<char> span, char trimChar)
        //{
        //    int start = 0;

        //    while (start < span.Length)
        //    {
        //        if (span[start] == trimChar)
        //        {
        //            ++start;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    return start;
        //}

        /// <summary>
        /// Delimits all leading occurrences of whitespace characters from the span.
        /// </summary>
        /// <param name="span">The source span from which the characters are removed.</param>
        internal static int ClampStart(this ReadOnlySpan<char> span)
        {
            // The code comes from https://source.dot.net/#System.Private.CoreLib/MemoryExtensions.Trim.cs,4ea9336c8966e7cb .
            int start = 0;
 
            for (; start < span.Length; start++)
            {
                if (!char.IsWhiteSpace(span[start]))
                {
                    break;
                }
            }
 
            return start;
        }
 
        /// <summary>
        /// Delimits all trailing occurrences of whitespace characters from the span.
        /// </summary>
        /// <param name="span">The source span from which the characters are removed.</param>
        /// <param name="start">The start index from which to search.</param>
        internal static int ClampEnd(this ReadOnlySpan<char> span, int start)
        {
            // The code comes from https://source.dot.net/#System.Private.CoreLib/MemoryExtensions.Trim.cs,4ea9336c8966e7cb .
            
            // Initially, start==len==0. If ClampStart trims all, start==len
            Debug.Assert((uint)start <= span.Length);
 
            int end = span.Length - 1;
 
            for (; end >= start; end--)
            {
                if (!char.IsWhiteSpace(span[end]))
                {
                    break;
                }
            }
 
            return end - start + 1;
        }
    }
    #endif
}

