
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    
    public static StringBuilder AppendBase64Encoded(this StringBuilder builder,
                                                    IList<byte> bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        if(builder is null) { throw new ArgumentNullException(nameof(builder)); }
        if(bytes is null) { throw new ArgumentNullException(nameof(bytes)); }

        bool insertLineBreaks = options.HasFlag(Base64FormattingOptions.InsertLineBreaks) && bytes.Count != 0;

        builder.EnsureCapacity(builder.Length + ComputeNeededCapacity(bytes.Count, insertLineBreaks));

        int startOfBase64 = builder.Length;
        Base64.AppendEncodedTo(builder, bytes);

        if(insertLineBreaks)
        {
            InsertLineBreaks(builder, startOfBase64);
        }

        return builder;
    }

    private static int ComputeNeededCapacity(int dataLength, bool insertLineBreaks)
    {
        int capacity = (int)Math.Ceiling(dataLength / 3.0) * 4;

        if(insertLineBreaks)
        {
            capacity += dataLength / Base64.LINE_LENGTH * Base64.LINE_BREAK.Length;
        }

        return capacity;
    }

    private static void InsertLineBreaks(StringBuilder builder, int startOfBase64)
    {
        int lastLineBreakIndex = builder.LastIndexOf('\n', startOfBase64);

        if (lastLineBreakIndex >= 0)
        {
            if (startOfBase64 - lastLineBreakIndex < Base64.LINE_LENGTH) { startOfBase64 = lastLineBreakIndex; }
        }

        int nextLineStart = startOfBase64 + Base64.LINE_LENGTH;
        while (nextLineStart < builder.Length)
        {
            builder.Insert(nextLineStart, Base64.LINE_BREAK);
            nextLineStart += Base64.LINE_BREAK.Length + Base64.LINE_LENGTH;
        }
    }

}
