using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class StringExtension
    {
        public static int LastIndexOf(this string s, ReadOnlySpan<char> value, int startIndex, int count, StringComparison comparisonType)
            => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().LastIndexOf(value, startIndex, count, comparisonType);
        
    }
}
