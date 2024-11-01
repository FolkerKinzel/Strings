using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Baz;
using FolkerKinzel.Strings;
using System.Buffers;

namespace LibraryTesters;

class Program
{
    static void Main()
    {
        //Console.WriteLine(Uri.HexEscape('e'));

        string test = "Test";
        char c = 'e';
        var searchValues = SearchValuesPolyfill.Create("abc");

        _ = SearchValuesPolyfill.Create("xyz".AsSpan());

        byte[] bytes = new byte[1];

        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder(test);
        ReadOnlySpan<char> roSpan = test.AsSpan();
        Span<char> span = ['x'];

        _ = sb1.Append(sb2, -17, sb2.Length);

        _ = test.Trim(stackalloc char[] { ',', ';' });
        _ = test.TrimStart(stackalloc char[] { ',', ';' });
        _ = test.TrimEnd(stackalloc char[] { ',', ';' });

        _ = test.Trim(test);
        _ = test.TrimStart(test);
        _ = test.TrimEnd(test);

        _ = test.Contains('e');

        _ = test.AsSpan().Contains('e');
        _ = span.Contains('e');


        _ = test.Contains('e', StringComparison.OrdinalIgnoreCase);


        _ = test.StartsWith('T');

        _ = test.EndsWith('T');

        _ = test.IndexOf('e', StringComparison.Ordinal);


        _ = test.Split('e');

        _ = test.Split('e', 2);

        _ = test.ReplaceLineEndings();
        _ = test.ReplaceLineEndings(Environment.NewLine);

        //#if !NETCOREAPP3_1
        _ = test.AsMemory().Trim();

        _ = test.AsMemory().TrimStart();

        _ = test.AsMemory().TrimEnd();
        //#endif

        var sb = new StringBuilder();

        _ = sb.Append("Test".AsSpan());

        sb.Replace("abc", null, 17);
        sb.Replace('a', 'b', 17);

        sb.AppendUrlEncoded("abc");

        //MemoryExtensions.Trim(test.AsMemory());

        _ = TextEncodingConverter.GetEncoding("iso-8859-1");

        _ = "c".IsAscii();

        _ = "test".IsAscii();

        _ = "test".AsSpan().IsAscii();
        _ = span.IsAscii();

        _ = sb.ContainsNonAscii();

        _ = sb.ContainsNonAscii(0);

        _ = sb.ContainsNonAscii(0, 0);

        _ = sb.ToUpperInvariant();
        _ = sb.ToUpperInvariant(0);
        _ = sb.ToUpperInvariant(0, 0);

        _ = sb.ToLowerInvariant();
        _ = sb.ToLowerInvariant(0);
        _ = sb.ToLowerInvariant(0, 0);

        _ = roSpan.ContainsAny([]);
        _ = roSpan.ContainsAny("xy");

        _ = span.TrimStart(roSpan);
        _ = span.TrimEnd(roSpan);
        _ = span.Trim(roSpan);


        //_ = roSpan.GetTrimmedLength();
        //_ = span.GetTrimmedLength();

        //_ = roSpan.GetTrimmedStart();
        //_ = span.GetTrimmedStart();

        _ = roSpan.IndexOfAnyExcept('a');
        _ = span.IndexOfAnyExcept('a');
        _ = roSpan.LastIndexOfAnyExcept('a');
        _ = span.LastIndexOfAnyExcept('a');

        _ = roSpan.IndexOfAnyExcept('a', 'b');
        _ = span.IndexOfAnyExcept('a', 'b');
        _ = roSpan.LastIndexOfAnyExcept('a', 'b');
        _ = span.LastIndexOfAnyExcept('a', 'b');

        _ = roSpan.IndexOfAnyExcept('a', 'b', 'c');
        _ = span.IndexOfAnyExcept('a', 'b', 'c');
        _ = roSpan.LastIndexOfAnyExcept('a', 'b', 'c');
        _ = span.LastIndexOfAnyExcept('a', 'b', 'c');

        _ = roSpan.IndexOfAnyExcept("abcd");
        _ = span.IndexOfAnyExcept("abcd");
        _ = roSpan.LastIndexOfAnyExcept("abcd");
        _ = span.LastIndexOfAnyExcept("abcd");

        _ = roSpan.IndexOfAnyExcept("abcd".AsSpan());
        _ = span.IndexOfAnyExcept("abcd".AsSpan());
        _ = roSpan.LastIndexOfAnyExcept("abcd".AsSpan());
        _ = span.LastIndexOfAnyExcept("abcd".AsSpan());

        _ = roSpan.IndexOfAnyExcept(searchValues);
        _ = span.IndexOfAnyExcept(searchValues);
        _ = roSpan.LastIndexOfAnyExcept(searchValues);
        _ = span.LastIndexOfAnyExcept(searchValues);

        _ = roSpan.ContainsAnyExcept('a');
        _ = span.ContainsAnyExcept('a');
        _ = roSpan.ContainsAnyExcept('a', 'b');
        _ = span.ContainsAnyExcept('a', 'b');
        _ = roSpan.ContainsAnyExcept('a', 'b', 'c');
        _ = span.ContainsAnyExcept('a', 'b', 'c');
        _ = roSpan.ContainsAnyExcept("abc");
        _ = span.ContainsAnyExcept("abc");
        _ = roSpan.ContainsAnyExcept("abc".AsSpan());
        _ = span.ContainsAnyExcept("abc".AsSpan());
        _ = roSpan.ContainsAnyExcept(searchValues);
        _ = span.ContainsAnyExcept(searchValues);

        _ = roSpan.Trim('a');
        _ = span.Trim('a');

        _ = roSpan.TrimStart('a');
        _ = span.TrimStart('a');

        _ = roSpan.TrimEnd('a');
        _ = span.TrimEnd('a');

        _ = roSpan.Trim("abc");
        _ = span.Trim("abc");

        _ = roSpan.TrimStart("abc");
        _ = span.TrimStart("abc");

        _ = roSpan.TrimEnd("abc");
        _ = span.TrimEnd("abc");

        _ = roSpan.CommonPrefixLength("abc");
        _ = span.CommonPrefixLength("abc");
        _ = roSpan.CommonPrefixLength("abc", null);
        _ = span.CommonPrefixLength("abc", null);

        _ = roSpan.IndexOfAnyInRange('a', 'c');
        _ = span.IndexOfAnyInRange('a', 'c');

        _ = roSpan.ContainsAnyInRange('a', 'c');
        _ = span.ContainsAnyInRange('a', 'c');

        test.Foo();

        _ = test.ContainsWhiteSpace();

        _ = test.ContainsAny(test.AsSpan());
        _ = test.ContainsAny(new char[0]);
        _ = test.ContainsAny('t', 's');
        _ = test.ContainsAny('t', 'e', 's');
        _ = test.IndexOfAny(test.AsSpan(), 0, 0);
        _ = test.IndexOfAny(test);
        _ = test.IndexOfAny(test, 0);
        _ = test.IndexOfAny(test, 0, 0);
        _ = test.ContainsAny(test);
        _ = test.LastIndexOfAny(test, 0, 0);
        _ = test.LastIndexOfAny(test, 0);
        _ = test.LastIndexOfAny(test);


        _ = test.LastIndexOfAny(test.AsSpan(), 0, 0);

        _ = sb.Contains('e');
        _ = sb.Contains('e', 0);
        _ = sb.Contains('e', 0, 0);
        _ = sb.IndexOf('e');
        _ = sb.IndexOf('e', 0);
        _ = sb.IndexOf('e', 0, 0);
        _ = sb.LastIndexOf('e');
        _ = sb.LastIndexOf('e', 0);
        _ = sb.LastIndexOf('e', 0, 0);

        _ = sb.Append(sb2, 0, 0);

        _ = roSpan.ContainsAny(roSpan);
        _ = span.ContainsAny(roSpan);

        _ = roSpan.ContainsAny("abc");
        _ = span.ContainsAny("abc");


        _ = roSpan.ContainsAny('e', 'f');
        _ = span.ContainsAny('e', 'f');

        _ = roSpan.ContainsAny('e', 'f', 'g');
        _ = span.ContainsAny('e', 'f', 'g');

        _ = roSpan.IndexOfAny(roSpan);
        _ = roSpan.IndexOfAny("abc");

        _ = span.IndexOfAny(roSpan);
        _ = span.IndexOfAny("abc");

        _ = roSpan.LastIndexOfAny(roSpan);
        _ = roSpan.LastIndexOfAny("abc");

        _ = span.LastIndexOfAny(roSpan);
        _ = span.LastIndexOfAny("abc");

        _ = roSpan.ContainsWhiteSpace();
        _ = span.ContainsWhiteSpace();


        _ = roSpan.StartsWith("test", StringComparison.OrdinalIgnoreCase);
        _ = roSpan.StartsWith("test");

        _ = span.StartsWith("test", StringComparison.OrdinalIgnoreCase);
        _ = span.StartsWith("test");

        _ = roSpan.EndsWith("test", StringComparison.OrdinalIgnoreCase);
        _ = roSpan.EndsWith("test");

        _ = span.EndsWith("test", StringComparison.OrdinalIgnoreCase);
        _ = span.EndsWith("test");

        _ = roSpan.StartsWith('t');
        _ = roSpan.EndsWith('t');

        _ = span.StartsWith('t');
        _ = span.EndsWith('t');

        _ = sb.StartsWith('t');
        _ = sb.EndsWith('t');

        _ = test.Split("es", 2, StringSplitOptions.RemoveEmptyEntries);
        _ = test.Split("es", StringSplitOptions.RemoveEmptyEntries);
        _ = test.Contains("es", StringComparison.OrdinalIgnoreCase);
        _ = test.Replace("es", "AN", StringComparison.OrdinalIgnoreCase);

        _ = roSpan.LastIndexOfAny(roSpan, roSpan.Length - 1, roSpan.Length);
        _ = roSpan.LastIndexOfAny("abc", roSpan.Length - 1, roSpan.Length);
        _ = roSpan.LastIndexOfAny(searchValues, roSpan.Length - 1, roSpan.Length);

        _ = span.LastIndexOfAny(roSpan, roSpan.Length - 1, roSpan.Length);
        _ = span.LastIndexOfAny("abc", roSpan.Length - 1, roSpan.Length);
        _ = span.LastIndexOfAny(searchValues, span.Length - 1, span.Length);

        _ = roSpan.IndexOf("bla", StringComparison.Ordinal);
        _ = roSpan.Contains("bla", StringComparison.Ordinal);

        _ = span.IndexOf("bla", StringComparison.Ordinal);
        _ = span.Contains("bla", StringComparison.Ordinal);


        _ = c.IsAscii();
        _ = c.IsBinaryDigit();

        _ = c.IsAsciiLetter();
        _ = c.IsAsciiLetterLower();
        _ = c.IsAsciiLetterUpper();
        _ = c.IsAsciiLetterOrDigit();
        _ = c.IsBetween('a', 'o');
        _ = c.IsAsciiDigit();
        _ = c.IsAsciiHexDigit();
        _ = c.IsAsciiHexDigitLower();
        _ = c.IsAsciiHexDigitUpper();

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

        _ = test.AsSpan().LastIndexOf("es", 3, 4, StringComparison.Ordinal);
        _ = test.AsSpan().LastIndexOf("es", StringComparison.Ordinal);


        _ = test.AsSpan().Contains("es", StringComparison.Ordinal);

        _ = span.LastIndexOf("es", 3, 4, StringComparison.Ordinal);
        _ = span.LastIndexOf("es", StringComparison.Ordinal);


        _ = span.Contains("es", StringComparison.Ordinal);


        _ = sb.Append(test.AsSpan());
        _ = sb.Append(test.AsMemory());

        _ = sb.AppendJoin(',', "one", "two");
        _ = sb.AppendJoin(',', new List<string>());

        _ = sb.AppendJoin("::", "one", "two");
        _ = sb.AppendJoin("::", new List<string>());

        _ = sb.AppendJoin(',', 42, 'x');
        _ = sb.AppendJoin("::", 42, 'x');

        _ = roSpan.Equals("USA", StringComparison.Ordinal);
        _ = span.Equals("USA", StringComparison.Ordinal);

        _ = sb.Trim("ab");
        _ = sb.TrimStart("ab");
        _ = sb.TrimEnd("ab");

        foreach (ReadOnlySpan<char> item in roSpan.EnumerateLines())
        {

        }

        foreach (ReadOnlySpan<char> item in span.EnumerateLines())
        {

        }

        //_ = sb.AppendLine(test.AsMemory());
        //_ = sb.AppendLine(test.AsSpan());

        Encoding.UTF8.GetString(bytes.AsSpan());

        const string Abc = "ABC";
        _ = StaticStringMethod.Create<string>(Abc.Length, Abc, (chars, str) => str.AsSpan().CopyTo(chars));
    }
}
