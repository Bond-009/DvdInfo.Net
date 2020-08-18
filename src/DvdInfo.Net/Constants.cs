namespace DvdInfo
{
    public static class Constants
    {
        public const long VersionNumberOffset = 0x20;
        public const long CategoryOffset = 0x22;
        public const long NumberOfVolumesOffset = 0x26;
        public const long VolumeNumberOffset = 0x28;
        public const long SideIdOffset = 0x2a;
        public const long NumberOfTitleSetsOffset = 0x3e;
        public const long ProviderIdOffset = 0x40;
        public const long VmgPositionOffset = 0x60;
        public const long VideoAttributesOffset = 0x100;

        public const int ProviderIdLength = 32;
    }
}
