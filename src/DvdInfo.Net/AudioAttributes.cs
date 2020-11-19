namespace DvdInfo
{
    public readonly struct AudioAttributes
    {
        private readonly ulong _attributes;

        public AudioAttributes(ulong attributes)
        {
            _attributes = attributes;
        }

        public AudioCodingMode CodingMode => (AudioCodingMode)(_attributes >> 61);

        public byte Quantization => (byte)((_attributes >> 54) & 0x03);

        public byte SampleRate => (byte)((_attributes >> 52) & 0x03);

        // Channels - 1 are stored, so increase by 1
        public byte Channels => (byte)(((_attributes >> 48) & 0x07) + 1);
    }
}
