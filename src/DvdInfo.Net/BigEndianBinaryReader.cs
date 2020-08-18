using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace DvdInfo
{
    /// <inheritdoc />
    public class BigEndianBinaryReader : BinaryReader
    {
        private const int BufferSize = 8;

        private readonly byte[] _buffer;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianBinaryReader"/> class.
        /// </summary>
        /// <param name="input">The input stream.</param>
        public BigEndianBinaryReader(Stream input)
            : this(input, Encoding.UTF8, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianBinaryReader"/> class.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public BigEndianBinaryReader(Stream input, Encoding encoding)
            : this(input, encoding, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianBinaryReader"/> class.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="leaveOpen"><c>true</c> to leave the stream open after the <see cref="BigEndianBinaryReader" /> object is disposed; otherwise, <c>false</c>.</param>
        public BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen)
            : base(input, encoding, leaveOpen)
        {
            _buffer = new byte[BufferSize];
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(GetType().Name);
            }
        }

        private ReadOnlySpan<byte> InternalRead(int numBytes)
        {
            ThrowIfDisposed();

            int bytesRead = 0;
            do
            {
                int n = BaseStream.Read(_buffer, bytesRead, numBytes - bytesRead);
                if (n == 0)
                {
                    ThrowHelper.ThrowEndOfStreamException();
                }

                bytesRead += n;
            } while (bytesRead < numBytes);

            return _buffer;
        }

        /// <summary>
        /// Reads a 2-byte signed integer from the current stream using big-endian encoding
        /// and advances the position of the stream by two bytes.
        /// </summary>
        /// <returns>A 2-byte signed integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override short ReadInt16() => BinaryPrimitives.ReadInt16BigEndian(InternalRead(2));

        /// <summary>
        /// Reads a 2-byte unsigned integer from the current stream using big-endian encoding
        /// and advances the position of the stream by two bytes.
        /// </summary>
        /// <returns>A 2-byte unsigned integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override ushort ReadUInt16() => BinaryPrimitives.ReadUInt16BigEndian(InternalRead(2));

        /// <summary>
        /// Reads a 4-byte signed integer from the current stream using big-endian encoding
        /// and advances the position of the stream by four bytes.
        /// </summary>
        /// <returns>A 4-byte signed integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override int ReadInt32() => BinaryPrimitives.ReadInt32BigEndian(InternalRead(4));

        /// <summary>
        /// Reads a 4-byte unsigned integer from the current stream using big-endian encoding
        /// and advances the position of the stream by four bytes.
        /// </summary>
        /// <returns>A 4-byte unsigned integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override uint ReadUInt32() => BinaryPrimitives.ReadUInt32BigEndian(InternalRead(4));

        /// <summary>
        /// Reads a 8-byte signed integer from the current stream using big-endian encoding
        /// and advances the position of the stream by eight bytes.
        /// </summary>
        /// <returns>A 8-byte signed integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override long ReadInt64() => BinaryPrimitives.ReadInt64BigEndian(InternalRead(8));

        /// <summary>
        /// Reads a 8-byte unsigned integer from the current stream using big-endian encoding
        /// and advances the position of the stream by eight bytes.
        /// </summary>
        /// <returns>A 8-byte unsigned integer read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override ulong ReadUInt64() => BinaryPrimitives.ReadUInt64BigEndian(InternalRead(8));

        /// <summary>
        /// Reads an 4-byte floating point value from the current stream using big-endian encoding
        /// and advances the current position of the stream by four bytes.
        /// </summary>
        /// <returns>An 4-byte floating point value read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override float ReadSingle() => BitConverter.Int32BitsToSingle(BinaryPrimitives.ReadInt32BigEndian(InternalRead(4)));

        /// <summary>
        /// Reads an 8-byte floating point value from the current stream using big-endian encoding
        /// and advances the current position of the stream by eight bytes.
        /// </summary>
        /// <returns>An 8-byte floating point value read from the current stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public override double ReadDouble() => BitConverter.Int64BitsToDouble(BinaryPrimitives.ReadInt64BigEndian(InternalRead(8)));

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            base.Dispose(disposing);

            _disposed = true;
        }
    }
}
