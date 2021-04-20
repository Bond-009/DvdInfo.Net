using System;
using System.Collections.Generic;
using Xunit;

namespace DvdInfo.Tests
{
    public class IfoHelperTests
    {
        public static IEnumerable<object[]> TryParseVersion_Invalid_TestData()
        {
            yield return new object[] { Array.Empty<byte>() };
            yield return new object[] { new byte[] { 0x00 } };
            yield return new object[] { new byte[] { 0x01 } };
            yield return new object[] { new byte[] { 0x01, 0x00 } };
            yield return new object[] { new byte[] { 0x01, 0x01 } };
        }

        [Theory]
        [MemberData(nameof(TryParseVersion_Invalid_TestData))]
        public void TryParseVersion_Invalid_False(byte[] source)
        {
            Assert.False(IfoHelper.TryParseVersion(source, out var version));
            Assert.Null(version);
        }

        public static IEnumerable<object[]> TryParseVersion_Valid_TestData()
        {
            yield return new object[] { new byte[] { 0x00, 0x00 }, new Version(0, 0) };
            yield return new object[] { new byte[] { 0x00, 0x01 }, new Version(0, 1) };
            yield return new object[] { new byte[] { 0x00, 0xa7 }, new Version(10, 7) };
            yield return new object[] { new byte[] { 0x00, 0xff }, new Version(15, 15) };
            yield return new object[] { new byte[] { 0x00, 0xa7, 0xff }, new Version(10, 7) };
        }

        [Theory]
        [MemberData(nameof(TryParseVersion_Valid_TestData))]
        public void TryParseVersion_Valid_Success(byte[] source, Version expected)
        {
            Assert.True(IfoHelper.TryParseVersion(source, out var version));
            Assert.Equal(expected, version);
        }
    }
}
