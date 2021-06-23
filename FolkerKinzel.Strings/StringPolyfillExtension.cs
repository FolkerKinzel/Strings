using System;

namespace FolkerKinzel.Strings
{
#if NETSTANDARD2_0 || NET45
    public static partial class StringPolyfillExtension
    {
        public static bool Contains(this string s, char value, StringComparison comparisonType)
            => s?.AsSpan().Contains(stackalloc[] { value }, comparisonType) ?? throw new NullReferenceException();

        public static int IndexOf(this string s, char value, StringComparison comparisonType)
            => s?.AsSpan().IndexOf(stackalloc[] { value }, comparisonType) ?? throw new NullReferenceException();



        public static string[] Split(this string s, char separator, StringSplitOptions options = StringSplitOptions.None)
            => s?.Split(new char[] { separator }, options) ?? throw new NullReferenceException();

        public static string[] Split(this string s, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
            => s?.Split(new char[] { separator }, count, options) ?? throw new NullReferenceException();



        public static bool StartsWith(this string s, char value)
            => s?.AsSpan().StartsWith(stackalloc[] { value }) ?? throw new NullReferenceException();


        public static bool EndsWith(this string s, char value)
            => s?.AsSpan().EndsWith(stackalloc[] { value }) ?? throw new NullReferenceException();
        
    }
#endif
}

