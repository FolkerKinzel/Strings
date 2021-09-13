using System;
using System.Text;
using FolkerKinzel.Strings;
using System.Linq;

#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1
using FolkerKinzel.Strings.Polyfills;
#endif

namespace LibraryTesters
{
    public static class Test
    {
        public static void Method()
        {
            string test = "Test";
            var span = test.AsSpan();
            char c = 'e';

            _ = test.Trim(stackalloc char[] { ',', ';' });
            _ = test.TrimStart(stackalloc char[] { ',', ';' });
            _ = test.TrimEnd(stackalloc char[] { ',', ';' });

            _ = test.Contains('e');

            _ = test.AsSpan().Contains('e');


            _ = test.Contains('e', StringComparison.OrdinalIgnoreCase);


            _ = test.StartsWith('T');

            _ = test.EndsWith('T');

            _ = test.IndexOf('e', StringComparison.Ordinal);


            _ = test.Split('e');

            _ = test.Split('e', 2);

            //#if !NETCOREAPP3_1
            _ = test.AsMemory().Trim();

            _ = test.AsMemory().TrimStart();

            _ = test.AsMemory().TrimEnd();
            //#endif

            var sb = new StringBuilder();

            _ = sb.Append("Test".AsSpan());

            //MemoryExtensions.Trim(test.AsMemory());

            _ = TextEncodingConverter.GetEncoding("iso-8859-1");

            _ = "c".IsAscii();

            _ = "test".IsAscii();

            _ = "test".AsSpan().IsAscii();

            _ = sb.ContainsNonAscii();

            _ = sb.ContainsNonAscii(0);

            _ = sb.ContainsNonAscii(0, 0);

            _ = sb.ToUpperInvariant();
            _ = sb.ToUpperInvariant(0);
            _ = sb.ToUpperInvariant(0, 0);

            _ = sb.ToLowerInvariant();
            _ = sb.ToLowerInvariant(0);
            _ = sb.ToLowerInvariant(0, 0);

            _ = test.AsSpan().ContainsAny(ReadOnlySpan<char>.Empty);

            _ = test.AsSpan().GetTrimmedLength();

            _ = test.AsSpan().GetTrimmedStart();

            _ = test.ContainsWhiteSpace();

            _ = test.ContainsAny(new char[0]);
            _ = test.ContainsAny(test.AsSpan());
            _ = test.ContainsAny('t', 's');
            _ = test.ContainsAny('t', 'e', 's');
            _ = test.IndexOfAny(test.AsSpan(), 0, 0);
            _ = test.LastIndexOfAny(test.AsSpan(), 0, 0);

            _ = sb.Contains('e');
            _ = sb.IndexOf('e');
            _ = sb.IndexOf('e', 0);
            _ = sb.IndexOf('e', 0, 0);
            _ = sb.LastIndexOf('e');
            _ = sb.LastIndexOf('e', 0);
            _ = sb.LastIndexOf('e', 0, 0);

            _ = sb.Append(sb, 0, 0);

            _ = span.ContainsAny(span);
            _ = span.ContainsAny('e', 'f');
            _ = span.ContainsAny('e', 'f', 'g');
            _ = span.IndexOfAny(span);
            _ = span.LastIndexOfAny(span);
            _ = span.ContainsWhiteSpace();

            _ = span.StartsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = span.StartsWith("test");

            _ = span.EndsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = span.EndsWith("test");

            _ = span.StartsWith('t');
            _ = span.EndsWith('t');

            _ = "c".StartsWith('t');
            _ = "c".EndsWith('t');

            _ = sb.StartsWith('t');
            _ = sb.EndsWith('t');

            _ = test.Split("es", 2, StringSplitOptions.RemoveEmptyEntries);
            _ = test.Split("es", StringSplitOptions.RemoveEmptyEntries);
            _ = test.Contains("es", StringComparison.OrdinalIgnoreCase);
            _ = test.Replace("es", "AN", StringComparison.OrdinalIgnoreCase);

            _ = span.LastIndexOfAny(span, span.Length - 1, span.Length);

            _ = c.IsAscii();
            _ = c.IsBinaryDigit();
            _ = c.IsDecimalDigit();
            _ = c.IsHexDigit();
            _ = c.ParseDecimalDigit();
            _ = c.ParseHexDigit();
            _ = c.IsControl();
            _ = c.IsDigit();
            _ = c.IsSurrogate();
            _ = c.IsHighSurrogate();
            _ = c.IsLowSurrogate();
            _ = c.IsLetter();
            _ = c.IsLetterOrDigit();
            _ = c.IsLower();
            _ = c.IsUpper();
            _ = c.IsNumber();
            _ = c.IsPunctuation();
            _ = c.IsSeparator();
            _ = c.IsSymbol();
            _ = c.IsWhiteSpace();
            _ = c.ToLowerInvariant();
            _ = c.ToUpperInvariant();

            _ = c.ParseBinaryDigit();
            _ = c.TryParseHexDigit(out int? _);
            _ = c.TryParseDecimalDigit(out int? _);
            _ = c.TryParseBinaryDigit(out int? _);

            _ = c.IsNewLine();


            _ = sb.Insert(0, span);

             _ = test.AsSpan().LastIndexOf("es", 3, 4, StringComparison.Ordinal);
            _ = test.AsSpan().LastIndexOf("es", StringComparison.Ordinal);

            _ = test.AsSpan().LastIndexOf("es".AsSpan(), 3, 4, StringComparison.Ordinal);
            _ = test.AsSpan().LastIndexOf("es".AsSpan(), StringComparison.Ordinal);


        }
    }
}
