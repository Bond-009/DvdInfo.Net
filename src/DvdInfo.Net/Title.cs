namespace DvdInfo
{
    public readonly struct Title
    {
        private readonly ulong _attributes;

        private readonly uint _vtsStartSector;

        public Title(ulong attributes, uint vtsStartSector)
        {
            _attributes = attributes;
            _vtsStartSector = vtsStartSector;
        }

        // TODO: title type

        public byte NumberOfAngles => (byte)((_attributes >> 48) & 0xff);

        public ushort NumberOfChapters => (ushort)((_attributes >> 32) & 0xffff);

        public ushort ParentalManagementMask => (ushort)((_attributes >> 16) & 0xffff);

        public byte VideoTitleSetNumber => (byte)((_attributes >> 8) & 0xff);

        public byte TitleNumberWithinVTS => (byte)(_attributes & 0xff);
    }
}
