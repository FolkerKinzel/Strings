// See https://aka.ms/new-console-template for more information
using FolkerKinzel.Strings;

Console.WriteLine("Library Tester:");
Console.WriteLine();
LibraryTesters.Test.TestMethod();

Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine();
Console.WriteLine("Test Program:");
Console.WriteLine();
TestMethod();

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0301:Simplify collection initialization",
            Justification = "Be sure targetting the right overload")]
static void TestMethod()
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
