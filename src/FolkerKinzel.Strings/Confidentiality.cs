namespace FolkerKinzel.Strings;

/// <summary>
/// Static class that allows customizing the library's behavior when highly 
/// confidential data needs to be processed.
/// </summary>
/// <threadsafety static="false" instance="false"/>
public static class Confidentiality
{
    /// <summary>
    /// If highly confidential data needs to be processed, set this property to <c>true</c> .
    /// </summary>
    /// <remarks>
    /// <para>
    /// If this property is <c>true</c>, arrays borrowed from <see cref="ArrayPool{T}.Shared"/> 
    /// will be emptied when returned. On the other hand, setting this property to <c>true</c> 
    /// has negative consequences for performance.
    /// </para>
    /// <note type="caution">
    /// This property is not thread-safe.
    /// </note>
    /// </remarks>
    public static bool IsConfidential { get; set; }
}
