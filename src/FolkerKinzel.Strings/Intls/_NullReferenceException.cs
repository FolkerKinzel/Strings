using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Intls;
[SuppressMessage("Style", "IDE1006:Naming Styles", 
    Justification = "Show as polyfill")]
internal static class _NullReferenceException
{
    internal static void ThrowIfNull([NotNull] object? argument, string paramName)
    {
        if (argument is null)
        { 
            throw new NullReferenceException(paramName); 
        }
    }
}
