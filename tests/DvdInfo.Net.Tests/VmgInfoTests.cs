using System;
using System.IO;
using Xunit;

namespace DvdInfo.Tests
{
    public class VmgInfoTests
    {
        [Fact]
        public void Test01()
        {
            var path = Path.Join("Test Data", "VIDEO_TS.IFO.01");
            var info = VmgInfo.Create(path);

            Assert.Equal(new Version(0, 0), info.Version);
            Assert.Equal(0x00fe0000u, info.Category);
            Assert.Equal(1, info.NumberOfVolumes);
            Assert.Equal(1, info.VolumeNumber);
            Assert.Equal(1, info.SideId);
            Assert.Equal(8, info.NumberOfTitleSets);
            Assert.Equal(0ul, info.VmgPos);

            Assert.Equal(13, info.TableOfTitles.Length);

            var tt1 = info.TableOfTitles[0];
            Assert.Equal(1, tt1.NumberOfAngles);
            Assert.Equal(13, tt1.NumberOfChapters);
            Assert.Equal(0, tt1.ParentalManagementMask);
            Assert.Equal(1, tt1.VideoTitleSetNumber);
            Assert.Equal(1, tt1.TitleNumberWithinVTS);

            // Video Attributes
            Assert.Equal(VideoCodingMode.Mpeg2, info.VideoAttributes.CodingMode);
            Assert.Equal(Standard.NTSC, info.VideoAttributes.Standard);
            Assert.Equal(Aspect.WideScreen, info.VideoAttributes.Aspect);
            Assert.False(info.VideoAttributes.AutomaticPanAndScan);
            Assert.True(info.VideoAttributes.AutomaticLetterbox);
            Assert.Equal(Resolution.Full, info.VideoAttributes.Resolution);
            Assert.False(info.VideoAttributes.Letterboxed);
            Assert.Equal(Film.Camera, info.VideoAttributes.Film);

            // Audio Attributes
            Assert.Equal(AudioCodingMode.AC3, info.AudioAttributes.CodingMode);
            Assert.Equal(3, info.AudioAttributes.Quantization);
            Assert.Equal(0, info.AudioAttributes.SampleRate);
            Assert.Equal(2, info.AudioAttributes.Channels);
        }
    }
}
