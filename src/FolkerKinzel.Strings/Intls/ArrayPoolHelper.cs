using System.Buffers;

namespace FolkerKinzel.Strings.Intls;

internal static class ArrayPoolHelper
{
    internal static SharedArray<T> Rent<T>(int minimumLength) => new(minimumLength);

    internal readonly struct SharedArray<T> : IDisposable
    {
        internal SharedArray(int minimumLength)
            => Value = ArrayPool<T>.Shared.Rent(minimumLength);

        internal T[] Value { get; }

        public void Dispose() => ArrayPool<T>.Shared.Return(Value, Confidentiality.Confidential);
    }
}
