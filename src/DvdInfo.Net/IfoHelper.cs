using System;
using System.Diagnostics.CodeAnalysis;

namespace DvdInfo
{
    public static class IfoHelper
    {
        public static bool TryParseVersion(ReadOnlySpan<byte> source, [NotNullWhen(true)] out Version? value)
        {
            value = null;

            if (source.Length < 2)
            {
                return false;
            }

            // First byte of the version number should be 0.
            if (source[0] != 0)
            {
                return false;
            }

            var tmp = source[1];
            value = new Version(tmp >> 4, tmp & 0x0f);
            return true;
        }
    }
}
