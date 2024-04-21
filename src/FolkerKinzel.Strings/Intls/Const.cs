namespace FolkerKinzel.Strings.Intls;

internal static class Const
{
    // According to the internal constant System.String.StackallockCharBufferSizeLimit
    // from the .NET sources
    internal const int StackallocCharThreshold = 256;

    internal const int StackallocByteThreshold = 2 * Const.StackallocCharThreshold;

}
