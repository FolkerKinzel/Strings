namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{

    private const int SIMPLE_ALGORITHM_THRESHOLD =
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
        15;
#else
        50;
#endif

}
