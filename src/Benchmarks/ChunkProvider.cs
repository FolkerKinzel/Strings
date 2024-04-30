using System;
using System.Text;

namespace Benchmarks;

internal static class ChunkProvider
{
    internal static bool TryGetChunk(StringBuilder builder, int index, out int chunkStartIndex, out ReadOnlySpan<char> span)
    {
        chunkStartIndex = 0;

        if (index < 0)
        {
            span = default;
            return false;
        }

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (index < chunkStartIndex + chunk.Length)
            {
                span = chunk.Span;
                return true;
            }

            chunkStartIndex += chunk.Length;
        }

        span = default;
        return false;
    }
}