namespace DvdInfo
{
    public readonly struct VideoAttributes
    {
        private readonly ushort _attributes;

        public VideoAttributes(ushort attributes)
        {
            _attributes = attributes;
        }

        public VideoCodingMode CodingMode => (VideoCodingMode)(_attributes >> 14);

        public Standard Standard => (Standard)((_attributes >> 12) & 0x03);

        public Aspect Aspect => (Aspect)((_attributes >> 10) & 0x03);

        // 1 = disallowed
        public bool AutomaticPanAndScan => ((_attributes >> 9) & 0x1) != 1;

        // 1 = disallowed
        public bool AutomaticLetterbox => ((_attributes >> 8) & 0x1) != 1;

        public Resolution Resolution => (Resolution)((_attributes >> 3) & 0x07);

        public bool Letterboxed => ((_attributes >> 2) & 0x1) != 0;

        public Film Film => (Film)(_attributes & 0x01);
    }
}
