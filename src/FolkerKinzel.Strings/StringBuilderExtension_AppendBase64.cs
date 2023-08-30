using System.Runtime.InteropServices;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Fügt den Inhalt einer <see cref="byte"/>-Enumeration als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Die <see cref="byte"/>-Enumeration, die die anzufügenden Daten enthält.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                                    IEnumerable<byte> bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None) =>
        bytes is null
               ? throw new ArgumentNullException(nameof(bytes))
               : builder.AppendBase64(ConvertToReadOnlySpan(bytes), options);



    /// <summary>
    /// Fügt den Inhalt eines <see cref="byte"/>-Arrays als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Das <see cref="byte"/>-Array, das die anzufügenden Daten enthält.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                                    byte[] bytes,
                                                    Base64FormattingOptions options = Base64FormattingOptions.None) =>
        builder.AppendBase64(bytes is null ? throw new ArgumentNullException(nameof(bytes)) : bytes.AsSpan(), options);


    /// <summary>
    /// Fügt den Inhalt einer schreibgeschützten Bytespanne als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Die schreibgeschützte Bytespanne, die die anzufügenden Daten enthält.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    public static StringBuilder AppendBase64(this StringBuilder builder,
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

    private static ReadOnlySpan<byte> ConvertToReadOnlySpan(IEnumerable<byte> bytes)
    {
        ReadOnlySpan<byte> span = bytes switch
        {
            byte[] arr => arr,
#if NET5_0_OR_GREATER
            List<byte> list => CollectionsMarshal.AsSpan(list),
#endif
            _ => bytes.ToArray(),
        };
        return span;
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
