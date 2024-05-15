using System.Text;

namespace Benchmarks;

static class StringBuilders
{
    internal static readonly StringBuilder _50 = new StringBuilder("a").Append(new string('a', 49));
    internal static readonly StringBuilder _10 = new StringBuilder("a").Append(new string('a', 9));
}