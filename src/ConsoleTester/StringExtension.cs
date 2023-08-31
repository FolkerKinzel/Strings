#if !NETCOREAPP3_1
#endif

using System;

namespace Baz;

public static class SpanExtension
{
    public static void Foo(this Span<char> span) { }
}


public static class StringExtension
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification = "<Ausstehend>")]
    public static void Foo(this string? s) { }
}
