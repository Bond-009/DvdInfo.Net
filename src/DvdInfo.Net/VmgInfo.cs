using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DvdInfo
{
    public class VmgInfo
    {
        /// <summary>
        /// Gets the VMG IFO File magic: <c>DVDVIDEO-VMG</c>.
        /// </summary>
        public static ReadOnlySpan<byte> Magic
            => new byte[] { 0x44, 0x56, 0x44, 0x56, 0x49, 0x44, 0x45, 0x4f, 0x2d, 0x56, 0x4d, 0x47 };

        private VmgInfo()
        {
            Version = new Version(0, 0);
            ProviderId = string.Empty;
            TableOfTitles = Array.Empty<Title>();
        }

        public Version Version { get; set; }

        public uint Category { get; set; }

        public ushort NumberOfVolumes { get; set; }

        public ushort VolumeNumber { get; set; }

        public byte SideId { get; set; }

        public ushort NumberOfTitleSets { get; set; }

        public string ProviderId { get; set; }

        public ulong VmgPos { get; set; }

        public VideoAttributes VideoAttributes { get; set; }

        public Title[] TableOfTitles { get; set; }

        public ushort AudioStreams { get; set; }

        public AudioAttributes AudioAttributes { get; set; }

        public static VmgInfo Create(string path)
            => Create(File.OpenRead(path));

        public static VmgInfo Create(Stream stream)
        {
            Span<byte> buffer = stackalloc byte[32];
            var id = buffer.Slice(0, 12);
            stream.Read(id);
            if (!id.SequenceEqual(Magic))
            {
                ThrowHelper.ThrowInvalidDataException("File doesn't start with VMG IFO magic.");
            }

            using var reader = new BigEndianBinaryReader(stream, Encoding.UTF8, true);

            stream.Seek(Constants.VersionNumberOffset, SeekOrigin.Begin);
            var versionSpan = buffer.Slice(0, 2);
            stream.Read(versionSpan); // 0x20

            var info = new VmgInfo();
            if (!IfoHelper.TryParseVersion(versionSpan, out var version))
            {
                ThrowHelper.ThrowInvalidDataException("First byte of the version number should be 0.");
            }

            info.Version = version;

            info.Category = reader.ReadUInt32(); // 0x22
            info.NumberOfVolumes = reader.ReadUInt16(); // 0x26
            info.VolumeNumber = reader.ReadUInt16(); // 0x28
            info.SideId = reader.ReadByte(); // 0x2a

            stream.Seek(Constants.NumberOfTitleSetsOffset, SeekOrigin.Begin);
            info.NumberOfTitleSets = reader.ReadUInt16(); // 0x3e

            int bytesRead = stream.Read(buffer); // 0x40
            Debug.Assert(
                bytesRead == Constants.ProviderIdLength,
                $"Expected {nameof(bytesRead)} to be {Constants.ProviderIdLength}, got {bytesRead}");
            info.ProviderId = Encoding.ASCII.GetString(buffer);

            info.VmgPos = reader.ReadUInt64(); // 0x60

            stream.Seek(Constants.TableOfTitlesPointerOffset, SeekOrigin.Begin);
            stream.Seek(reader.ReadUInt32() * Constants.DvdSectorSize, SeekOrigin.Begin);
            info.TableOfTitles = ReadTableOfTitles(reader);

            stream.Seek(Constants.VideoAttributesOffset, SeekOrigin.Begin);
            info.VideoAttributes = new VideoAttributes(reader.ReadUInt16()); // 0x100

            info.AudioStreams = reader.ReadUInt16(); // 0x102

            info.AudioAttributes = new AudioAttributes(reader.ReadUInt64()); // 0x104

            return info;
        }

        internal static Title[] ReadTableOfTitles(BinaryReader reader)
        {
            ushort numTitles = reader.ReadUInt16();
            reader.BaseStream.Seek(6, SeekOrigin.Current);

            var titles = new Title[numTitles];
            for (int i = 0; i < numTitles; i++)
            {
                titles[i] = new Title(reader.ReadUInt64(), reader.ReadUInt32());
            }

            return titles;
        }
    }
}
