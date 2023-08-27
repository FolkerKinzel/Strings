using System.Runtime.InteropServices;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{

    public static StringBuilder AppendBase64Encoded(this StringBuilder builder,
                                                    IEnumerable<byte> bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        if (bytes is null) 
        { 
            throw new ArgumentNullException(nameof(bytes)); 
        }

        ReadOnlySpan<byte> span = bytes switch
        {
            byte[] arr => arr,
#if NET5_0_OR_GREATER
            List<byte> list => CollectionsMarshal.AsSpan(list),
#endif
            _ => bytes.ToArray(),
        };

        return builder.AppendBase64Encoded(span, options);
    }


    public static StringBuilder AppendBase64Encoded(this StringBuilder builder,
                                                    ReadOnlySpan<byte> bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        if (builder is null) 
        { 
            throw new ArgumentNullException(nameof(builder));
        }

        bool insertLineBreaks = options.HasFlag(Base64FormattingOptions.InsertLineBreaks) && !bytes.IsEmpty;
        builder.EnsureCapacity(builder.Length + ComputeNeededCapacity(bytes.Length, insertLineBreaks));
        int startOfBase64 = builder.Length;

        Base64.AppendEncodedTo(builder, bytes);

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
            capacity += dataLength / Base64.LINE_LENGTH * Base64.LINE_BREAK.Length;
        }

        return capacity;
    }

    private static void InsertLineBreaks(StringBuilder builder, int startOfBase64)
    {
        int currentLineStartIndex = builder.LastIndexOf('\n', startOfBase64) + 1;
        
        if (startOfBase64 - currentLineStartIndex < Base64.LINE_LENGTH)
        { 
            startOfBase64 = currentLineStartIndex; 
        }
        else
        {
            builder.Insert(startOfBase64, Base64.LINE_BREAK);
            startOfBase64 += Base64.LINE_BREAK.Length;
        }
        

        int nextLineStart = startOfBase64 + Base64.LINE_LENGTH;
        while (nextLineStart < builder.Length)
        {
            builder.Insert(nextLineStart, Base64.LINE_BREAK);
            nextLineStart += Base64.LINE_BREAK.Length + Base64.LINE_LENGTH;
        }
    }

}
