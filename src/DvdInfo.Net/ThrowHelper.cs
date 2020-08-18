using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace DvdInfo
{
    /// <summary>
    /// Provides methods for throwing common exceptions.
    /// </summary>
    public static class ThrowHelper
    {
        /// <summary>
        /// Throws a new <see cref="ArgumentException" /> with the specified parameters.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }

        /// <summary>
        /// Throws a new <see cref="ArgumentException" /> with the specified parameters.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentException(string message, string paramName)
        {
            throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Throws a new <see cref="ArgumentOutOfRangeException" /> with the specified parameters.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }

        /// <summary>
        /// Throws a new <see cref="ArgumentOutOfRangeException" /> with the specified parameters.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string paramName, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        /// <summary>
        /// Throws a new <see cref="ArgumentNullException" /> with the specified parameters.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Throws a new <see cref="NotSupportedException" /> with the specified parameters.
        /// </summary>
        [DoesNotReturn]
        public static void ThrowNotSupportedException()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Throws a new <see cref="NotSupportedException" /> with the specified parameters.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [DoesNotReturn]
        public static void ThrowNotSupportedException(string message)
        {
            throw new NotSupportedException(message);
        }

        /// <summary>
        /// Throws a new <see cref="InvalidDataException" /> with the specified parameters.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [DoesNotReturn]
        public static void ThrowInvalidDataException(string message)
        {
            throw new InvalidDataException(message);
        }

        /// <summary>
        /// Throws a new <see cref="FileNotFoundException" /> with the specified parameters.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [DoesNotReturn]
        public static void ThrowFileNotFoundException(string message)
        {
            throw new FileNotFoundException(message);
        }

        /// <summary>
        /// Throws a new <see cref="EndOfStreamException" /> with the specified parameters.
        /// </summary>
        [DoesNotReturn]
        public static void ThrowEndOfStreamException()
        {
            throw new EndOfStreamException();
        }

        /// <summary>
        /// Throws a new <see cref="ObjectDisposedException" /> with the specified parameters.
        /// </summary>
        /// <param name="objectName">The name of the disposed object.</param>
        [DoesNotReturn]
        public static void ThrowObjectDisposedException(string objectName)
        {
            throw new ObjectDisposedException(objectName);
        }
    }
}
