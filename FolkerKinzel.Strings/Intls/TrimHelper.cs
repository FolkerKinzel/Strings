using System;

namespace FolkerKinzel.Strings
{
    internal static class TrimHelper
    {
        internal static int GetLength(ReadOnlySpan<char> span, char trimChar)
        {
            int length = span.Length;

            while (length > 0)
            {
                if (span[length - 1] == trimChar)
                {
                    --length;
                }
                else
                {
                    break;
                }
            }

            return length;
        }


        internal static int GetStart(ReadOnlySpan<char> span, char trimChar)
        {
            int start = 0;

            while (start < span.Length)
            {
                if (span[start] == trimChar)
                {
                    ++start;
                }
                else
                {
                    break;
                }
            }

            return start;
        }
    }
}

