using System.Runtime.InteropServices;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{

    public static StringBuilder AppendBase64Encoded(this StringBuilder builder,
                                                    IEnumerable<byte> bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        if (builder is null) { throw new ArgumentNullException(nameof(builder)); }
        if (bytes is null) { throw new ArgumentNullException(nameof(bytes)); }

        int startOfBase64 = builder.Length;
        ReadOnlySpan<byte> span = bytes switch
        {
            byte[] arr => arr,
#if NET5_0_OR_GREATER
            List<byte> list => CollectionsMarshal.AsSpan(list),
#endif
            _ => bytes.ToArray(),
        };

        bool insertLineBreaks = options.HasFlag(Base64FormattingOptions.InsertLineBreaks) && !span.IsEmpty;
        builder.EnsureCapacity(builder.Length + ComputeNeededCapacity(span.Length, insertLineBreaks));

        Base64New.AppendEncodedTo(builder, span);

        if (insertLineBreaks)
        {
            InsertLineBreaks(builder, startOfBase64);
        }

        return builder;
    }

    private static int ComputeNeededCapacity(int dataLength, bool insertLineBreaks)
    {
        int capacity = (int)Math.Ceiling(dataLength / 3.0) * 4;

        if (insertLineBreaks)
        {
            capacity += dataLength / Base64New.LINE_LENGTH * Base64New.LINE_BREAK.Length;
        }

        return capacity;
    }

    private static void InsertLineBreaks(StringBuilder builder, int startOfBase64)
    {
        int lastLineBreakIndex = builder.LastIndexOf('\n', startOfBase64);

        if (lastLineBreakIndex >= 0)
        {
            if (startOfBase64 - lastLineBreakIndex < Base64New.LINE_LENGTH) { startOfBase64 = lastLineBreakIndex; }
        }

        int nextLineStart = startOfBase64 + Base64New.LINE_LENGTH;
        while (nextLineStart < builder.Length)
        {
            builder.Insert(nextLineStart, Base64New.LINE_BREAK);
            nextLineStart += Base64New.LINE_BREAK.Length + Base64New.LINE_LENGTH;
        }
    }

}
