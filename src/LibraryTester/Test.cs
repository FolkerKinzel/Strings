using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FolkerKinzel.Strings;

namespace LibraryTesters
{
    public static class Test
    {
        private static readonly char[] _array = ['x'];

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0301:Simplify collection initialization",
            Justification = "Be sure targetting the right overload")]
        public static void TestMethod()
        {
            char[] arr = ['x'];
            const string s = "a";
            Console.WriteLine(" String.IndexOfAny(Char[])");
            Console.WriteLine(" Needles empty: {0}", s.IndexOfAny(Array.Empty<char>()));
            Console.WriteLine(" String empty: {0}", string.Empty.IndexOfAny(arr));
            Console.WriteLine(" Needles + String empty: {0}", string.Empty.IndexOfAny(Array.Empty<char>()));
            Console.WriteLine();
            Console.WriteLine(" String.LastIndexOfAny(Char[])");
            Console.WriteLine(" Needles empty: {0}", s.LastIndexOfAny(Array.Empty<char>()));
            Console.WriteLine(" String empty: {0}", string.Empty.LastIndexOfAny(arr));
            Console.WriteLine(" Needles + String empty: {0}", string.Empty.LastIndexOfAny(Array.Empty<char>()));
            Console.WriteLine();
            Console.WriteLine(" ReadOnlySpan<Char>.IndexOfAny(ReadOnlySpan<Char>)");
            Console.WriteLine(" Needles empty: {0}", MemoryExtensions.IndexOfAny(s.AsSpan(), ReadOnlySpan<char>.Empty));
            Console.WriteLine(" String empty: {0}", MemoryExtensions.IndexOfAny(ReadOnlySpan<char>.Empty, arr));
            Console.WriteLine(" Needles + String empty: {0}", MemoryExtensions.IndexOfAny(ReadOnlySpan<char>.Empty, ReadOnlySpan<char>.Empty));
            Console.WriteLine();
            Console.WriteLine(" ReadOnlySpan<Char>.ContainsAny(ReadOnlySpan<Char>)");
            Console.WriteLine(" Needles empty: {0}", s.AsSpan().ContainsAny(ReadOnlySpan<char>.Empty));
            Console.WriteLine(" String empty: {0}", ReadOnlySpan<char>.Empty.ContainsAny(arr));
            Console.WriteLine(" Needles + String empty: {0}", ReadOnlySpan<char>.Empty.ContainsAny(ReadOnlySpan<char>.Empty));
            Console.WriteLine();
            Console.WriteLine(" ReadOnlySpan<Char>.LastIndexOfAny(ReadOnlySpan<Char>)");
            Console.WriteLine(" Needles empty: {0}", MemoryExtensions.LastIndexOfAny(s.AsSpan(), ReadOnlySpan<char>.Empty));
            Console.WriteLine(" String empty: {0}", MemoryExtensions.LastIndexOfAny(ReadOnlySpan<char>.Empty, arr));
            Console.WriteLine(" Needles + String empty: {0}", MemoryExtensions.LastIndexOfAny(ReadOnlySpan<char>.Empty, ReadOnlySpan<char>.Empty));
            Console.WriteLine();
        }

        public static void Method()
        {
            string test = "Test";
            var roSpan = test.AsSpan();
            var span = _array.AsSpan();

            var searchValues = SearchValuesPolyfill.Create("abc");

            _ = SearchValuesPolyfill.Create("xyz".AsSpan());

            char c = 'e';
            byte[] bytes = new byte[1];


            _ = test.Trim(stackalloc char[] { ',', ';' });
            _ = test.TrimStart(stackalloc char[] { ',', ';' });
            _ = test.TrimEnd(stackalloc char[] { ',', ';' });

            _ = test.Trim(test);
            _ = test.TrimStart(test);
            _ = test.TrimEnd(test);

            _ = test.Contains('e');

            _ = test.AsSpan().Contains('e');


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

            sb.Replace("abc", null, 17);
            sb.Replace('a', 'b', 17);

            sb.AppendUrlEncoded("abc");

            _ = sb.Append("Test".AsSpan());

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

            _ = test.AsSpan().ContainsAny([]);
            _ = test.AsSpan().ContainsAny("abc");


            //_ = test.AsSpan().GetTrimmedLength();
            //_ = span.GetTrimmedLength();

            //_ = test.AsSpan().GetTrimmedStart();
            //_ = span.GetTrimmedStart();

            _ = test.ContainsWhiteSpace();

            _ = test.ContainsAny(new char[0]);
            _ = test.ContainsAny(test.AsSpan());
            _ = test.ContainsAny('t', 's');
            _ = test.ContainsAny('t', 'e', 's');
            _ = test.IndexOfAny(test.AsSpan(), 0, 0);
            _ = test.LastIndexOfAny(test.AsSpan(), 0, 0);
            _ = test.IndexOfAny(test);
            _ = test.IndexOfAny(test, 0);
            _ = test.IndexOfAny(test, 0, 0);
            _ = test.ContainsAny(test);
            _ = test.LastIndexOfAny(test, 0, 0);
            _ = test.LastIndexOfAny(test, 0);
            _ = test.LastIndexOfAny(test);

            _ = sb.Contains('e');
            _ = sb.Contains('e', 0);
            _ = sb.Contains('e', 0, 0);
            _ = sb.IndexOf('e');
            _ = sb.IndexOf('e', 0);
            _ = sb.IndexOf('e', 0, 0);
            _ = sb.LastIndexOf('e');
            _ = sb.LastIndexOf('e', 0);
            _ = sb.LastIndexOf('e', 0, 0);

            _ = sb.Append(sb, 0, 0);
            _ = sb.Append(test.AsMemory());
            _ = sb.Append(sb);

            _ = sb.Trim("ab");
            _ = sb.TrimStart("ab");
            _ = sb.TrimEnd("ab");

            _ = roSpan.ContainsAny(roSpan);
            _ = roSpan.ContainsAny("abc");

            _ = roSpan.ContainsAny('e', 'f');
            _ = roSpan.ContainsAny('e', 'f', 'g');
            _ = roSpan.IndexOfAny(roSpan);
            _ = roSpan.IndexOfAny("abc");
            _ = roSpan.LastIndexOfAny(roSpan);
            _ = roSpan.LastIndexOfAny("abc");
            _ = roSpan.ContainsWhiteSpace();
            _ = roSpan.StartsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = roSpan.StartsWith("test");
            _ = roSpan.EndsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = roSpan.EndsWith("test");
            _ = roSpan.StartsWith('t');
            _ = roSpan.EndsWith('t');
            _ = roSpan.Contains('e');
            _ = span.Contains('e');
            _ = roSpan.IndexOf("bla", StringComparison.Ordinal);
            _ = roSpan.Contains("bla", StringComparison.Ordinal);

            _ = span.IndexOf("bla", StringComparison.Ordinal);
            _ = span.Contains("bla", StringComparison.Ordinal);

            _ = span.TrimStart(roSpan);
            _ = span.TrimEnd(roSpan);
            _ = span.Trim(roSpan);

            _ = span.TrimStart("");
            _ = span.TrimEnd("");
            _ = span.Trim("");


            _ = span.ContainsAny('e', 'f');
            _ = span.ContainsAny('e', 'f', 'g');
            _ = span.IndexOfAny(roSpan);
            _ = span.IndexOfAny("abc");
            _ = span.LastIndexOfAny(roSpan);
            _ = span.LastIndexOfAny("abc");
            _ = span.ContainsWhiteSpace();
            _ = span.StartsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = span.StartsWith("test");
            _ = span.EndsWith("test", StringComparison.OrdinalIgnoreCase);
            _ = span.EndsWith("test");
            _ = span.StartsWith('t');
            _ = span.EndsWith('t');

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

            _ = "c".StartsWith('t');
            _ = "c".EndsWith('t');

            _ = sb.StartsWith('t');
            _ = sb.EndsWith('t');

            _ = test.Split("es", 2, StringSplitOptions.RemoveEmptyEntries);
            _ = test.Split("es", StringSplitOptions.RemoveEmptyEntries);
            _ = test.Contains("es", StringComparison.OrdinalIgnoreCase);
            _ = test.Replace("es", "AN", StringComparison.OrdinalIgnoreCase);

            _ = roSpan.LastIndexOfAny(roSpan, roSpan.Length - 1, roSpan.Length);
            _ = roSpan.LastIndexOfAny("abc", roSpan.Length - 1, roSpan.Length);
            _ = roSpan.LastIndexOfAny(searchValues, roSpan.Length - 1, roSpan.Length);

            _ = span.LastIndexOfAny(roSpan, span.Length - 1, span.Length);
            _ = span.LastIndexOfAny("abc", span.Length - 1, span.Length);
            _ = span.LastIndexOfAny(searchValues, span.Length - 1, span.Length);

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


            _ = sb.Insert(0, roSpan);

            _ = test.AsSpan().LastIndexOf("es", 3, 4, StringComparison.Ordinal);
            _ = test.AsSpan().LastIndexOf("es", StringComparison.Ordinal);
            _ = test.AsSpan().LastIndexOf("es".AsSpan(), 3, 4, StringComparison.Ordinal);
            _ = test.AsSpan().LastIndexOf("es".AsSpan(), StringComparison.Ordinal);
            _ = test.AsSpan().Contains("es", StringComparison.Ordinal);

            _ = span.LastIndexOf("es", 3, 4, StringComparison.Ordinal);
            _ = span.LastIndexOf("es", StringComparison.Ordinal);
            _ = span.LastIndexOf("es".AsSpan(), 3, 4, StringComparison.Ordinal);
            _ = span.LastIndexOf("es".AsSpan(), StringComparison.Ordinal);
            _ = span.Contains("es", StringComparison.Ordinal);

            _ = sb.Append(test.AsSpan());
            _ = sb.Append(test.AsMemory());

            _ = sb.Insert(0, test.AsSpan());
            _ = sb.Insert(0, test.AsMemory());

            _ = sb.AppendLine(test.AsMemory());
            _ = sb.AppendLine(test.AsSpan());

            _ = sb.AppendJoin(',', "one", "two");
            _ = sb.AppendJoin(',', new List<string>());


            _ = sb.AppendJoin("::", "one", "two");
            _ = sb.AppendJoin("::", new List<string>());

            _ = sb.AppendJoin(',', 42, 'x');
            _ = sb.AppendJoin("::", 42, 'x');

            _ = roSpan.Equals("USA", StringComparison.Ordinal);
            _ = span.Equals("USA", StringComparison.Ordinal);


            _ = Encoding.UTF8.GetString(bytes.AsSpan());

            _ = span.Trim();
            _ = span.TrimStart();
            _ = span.TrimEnd();
            _ = span.IsWhiteSpace();

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

            const string Abc = "ABC";
            _ = StaticStringMethod.Create<string>(Abc.Length, Abc, (chars, str) => str.AsSpan().CopyTo(chars));

        }
    }
}
