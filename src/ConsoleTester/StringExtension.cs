#if !NETCOREAPP3_1
#endif

namespace Baz
{
    public static class StringExtension
    {
        public static void Foo(this string? s) { }
    }
}
