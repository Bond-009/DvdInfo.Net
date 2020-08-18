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
    }
}
