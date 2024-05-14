using System.Text;

namespace Benchmarks;

static class StringBuilders
{
    internal static readonly StringBuilder _50 = new StringBuilder(new string('a', 25)).Append(new string('a', 25));
    internal static readonly StringBuilder _10 = new StringBuilder(new string('a', 5)).Append(new string('a', 5));
}